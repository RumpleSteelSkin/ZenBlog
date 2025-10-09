import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Modal} from 'bootstrap';
import {CategoryService} from '../../../_services/category-service';
import {SweetalertService} from '../../../_services/sweetalert-service';
import {CategoryResponseDTO} from '../../../_models/Categories/CategoryResponseDTO';
import {CategoryCreateDTO} from '../../../_models/Categories/CategoryCreateDTO';
import {CategoryUpdateDTO} from '../../../_models/Categories/CategoryUpdateDTO';
import {DatePipe} from '@angular/common';

declare const alertify: any;

@Component({
  selector: 'category',
  templateUrl: './category.html',
  styleUrls: ['./category.css'],
  imports: [FormsModule, DatePipe]
})
export class Category implements AfterViewInit {
  categories: CategoryResponseDTO[] = [];
  newCategory: CategoryCreateDTO = new CategoryCreateDTO();
  editCategory: CategoryUpdateDTO = new CategoryUpdateDTO();
  errors: any[] = [];

  @ViewChild('updateModal', {static: false}) updateModal!: ElementRef;
  @ViewChild('createModal', {static: false}) createModal!: ElementRef;

  private modalInstances: Map<ElementRef, Modal> = new Map();

  constructor(private categoryService: CategoryService, private sweetalertService: SweetalertService) {
    this.get();
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
    this.categoryService.get().subscribe({
      next: res => this.categories = res.data,
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

  create(form: any) {
    this.categoryService.create(this.newCategory).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.createModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Category Created Successfully");
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

  onSelected(model: CategoryUpdateDTO) {
    this.editCategory = structuredClone(model);
    this.errors = [];
  }

  update(form: any) {
    this.categoryService.update(this.editCategory).subscribe({
      next: () => {
        this.errors = [];
        form.resetForm();
        this.modalInstances.get(this.updateModal)?.hide();
        this.forceCleanup();
        this.get();
        alertify.success("Category Updated Successfully");
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
      this.categoryService.remove(id).subscribe({
        next: () => {
          this.get();
          alertify.success("Category Deleted Successfully");
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
