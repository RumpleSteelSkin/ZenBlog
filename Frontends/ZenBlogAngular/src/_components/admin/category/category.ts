import {Component} from '@angular/core';
import {CategoryService} from '../../../_services/category-service';
import {DatePipe} from '@angular/common';
import {CategoryResponseDTO} from '../../../_models/Categories/CategoryResponseDTO';
import {CategoryCreateDTO} from '../../../_models/Categories/CategoryCreateDTO';
import {FormsModule} from '@angular/forms';

declare const alertify: any;

@Component({
  selector: 'category',
  imports: [
    DatePipe,
    FormsModule
  ],
  templateUrl: './category.html',
  styleUrl: './category.css'
})
export class Category {
  categories: CategoryResponseDTO[] = [];
  newCategory: CategoryCreateDTO = new CategoryCreateDTO();
  selectedId: number;
  errors: any = [];

  constructor(private categoryService: CategoryService) {
    this.get();
  }

  get() {
    this.categoryService.get().subscribe({
      next: result => {
        this.categories = result.data;
      },
      error: result => alertify.error(result.error.errors[0].errorMessage),
    });
  }

  create() {
    this.categoryService.create(this.newCategory).subscribe({
      next: result => {
        this.newCategory = {name: ''};
      },
      error: result => {
        alertify.error("An error occurred");
        if (result.status === 400) {
          this.errors = result.error.errors;
        }
        alertify.error(result.error.errors[0].errorMessage)
      },
      complete: () => {
        alertify.success("Category Created Successfully")
        location.reload()
      }
    });
  }
}

