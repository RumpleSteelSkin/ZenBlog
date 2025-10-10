import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CategoryResponseDTO} from '../_models/Categories/CategoryResponseDTO';
import {CategoryCreateDTO} from '../_models/Categories/CategoryCreateDTO';
import {CategoryUpdateDTO} from '../_models/Categories/CategoryUpdateDTO';
import {BaseService} from './base-service';
import {CategoryWithBlogsResponseDTO} from '../_models/Categories/CategoryWithBlogsResponseDTO';
import {ResultDTO} from '../_models/Base/ResultDTO';

@Injectable({
  providedIn: 'root'
})

export class CategoryService extends BaseService<CategoryResponseDTO, CategoryCreateDTO, CategoryUpdateDTO> {
  protected baseUrl = "https://localhost:7000/api/categories";

  constructor(http: HttpClient) {
    super(http);
  }

  getCategoriesWithBlogs() {
    return this.http.get<ResultDTO<CategoryWithBlogsResponseDTO[]>>(`${this.baseUrl}/WithBlogs`);
  }
}
