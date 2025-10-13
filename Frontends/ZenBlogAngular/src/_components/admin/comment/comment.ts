import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
import {CommentResponseDTO} from '../../../_models/Comments/CommentResponseDTO';
import {CommentCreateDTO} from '../../../_models/Comments/CommentCreateDTO';
import {CommentUpdateDTO} from '../../../_models/Comments/CommentUpdateDTO';
import {Modal} from 'bootstrap';
import {CommentService} from '../../../_services/comment-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {DatePipe} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BlogService} from '../../../_services/blog-service';
import {BlogResponseDTO} from '../../../_models/Blogs/BlogResponseDTO';

declare const alertify: any;

@Component({
  selector: 'comment',
  imports: [
    DatePipe,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './comment.html',
  styleUrl: './comment.css'
})
export class Comment implements AfterViewInit {
  comments: CommentResponseDTO[] = [];
  newComment: CommentCreateDTO = new CommentCreateDTO();
  editComment: CommentUpdateDTO = new CommentUpdateDTO();
  errors: any[] = [];
  blogs: BlogResponseDTO[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private commentService: CommentService, private sweetalertService: SweetalertService, private blogService: BlogService) {
    this.get();
    this.getBlogs();
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
    this.commentService.get().subscribe({
      next: res => {
        this.comments = res.data
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

  getBlogs() {
    this.blogService.get().subscribe({
      next: res => this.blogs = res.data,
      error: err => {
        if (err.status === 400) {
          this.errors = err.error.errors;
        }
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }
    })
  }

  create(form: any) {
    this.commentService.create(this.newComment).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Comment Created Successfully");
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

  onSelected(model: CommentUpdateDTO) {
    this.editComment = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.commentService.update(this.editComment).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Comment Updated Successfully");
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
      this.commentService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Comment Deleted Successfully");
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
