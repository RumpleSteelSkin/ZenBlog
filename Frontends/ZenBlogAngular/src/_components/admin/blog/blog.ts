import {AfterViewInit, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {Modal} from 'bootstrap';
import {BlogService} from '../../../_services/blog-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {BlogResponseDTO} from '../../../_models/Blogs/BlogResponseDTO';
import {BlogCreateDTO} from '../../../_models/Blogs/BlogCreateDTO';
import {BlogUpdateDTO} from '../../../_models/Blogs/BlogUpdateDTO';
import {DatePipe} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {CategoryService} from '../../../_services/category-service';
import {CategoryResponseDTO} from '../../../_models/Categories/CategoryResponseDTO';

declare const alertify: any;

@Component({
  selector: 'app-blog',
  imports: [
    DatePipe,
    FormsModule
  ],
  templateUrl: './blog.html',
  styleUrl: './blog.css'
})
export class Blog implements AfterViewInit, OnInit {
  blogs: BlogResponseDTO[] = [];
  categories: CategoryResponseDTO[] = [];
  newBlog: BlogCreateDTO = new BlogCreateDTO();
  editBlog: BlogUpdateDTO = new BlogUpdateDTO();
  errors: any[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private blogService: BlogService, private categoryService: CategoryService, private sweetalertService: SweetalertService) {
  }

  ngOnInit() {
    this.get()
    this.getCategories()
  }

  getCategories() {
    this.categoryService.get().subscribe({
      next: res => this.categories = res.data,
      error: err => {
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  ngAfterViewInit(): void {
    if (this.createModal) {
      this.modalInstances.set(this.createModal, new Modal(this.createModal.nativeElement));
    }
    if (this.updateModal) {
      this.modalInstances.set(this.updateModal, new Modal(this.updateModal.nativeElement));
    }
  }

  get() {
    this.errors = [];
    this.blogService.get().subscribe({
      next: res => this.blogs = res.data,
      error: err => {
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  create(form: any) {
    this.blogService.create(this.newBlog).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Blog Created Successfully");
      },
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  onSelected(model: BlogUpdateDTO) {
    this.editBlog = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.blogService.update(this.editBlog).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Blog Updated Successfully");
      },
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    });
  }

  async delete(id: string) {
    const confirmed = await this.sweetalertService.areYouSure();
    if (confirmed) {
      this.blogService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Blog Deleted Successfully");
        },
        error: err => {
          for (let i = 0; i < err.error.errors.length; i++) {
            alertify.error(err.error.errors[i].errorMessage);
          }
        }
      });
    }
  }

  private forceCleanup() {
    document.body.classList.remove('modal-open');
    document.body.style.removeProperty('padding-right');
    const backdrops = document.getElementsByClassName('modal-backdrop');
    while (backdrops.length > 0) {
      backdrops[0].remove();
    }
  }
}
