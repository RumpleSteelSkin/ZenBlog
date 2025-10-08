import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ResultDTO} from '../_models/Base/ResultDTO';
import {CategoryResponseDTO} from '../_models/Categories/CategoryResponseDTO';
import {CategoryCreateDTO} from '../_models/Categories/CategoryCreateDTO';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = "https://localhost:7000/api/categories";

  constructor(private http: HttpClient) {
  }

  get() {
    return this.http.get<ResultDTO<CategoryResponseDTO[]>>(this.baseUrl);
  }

  create(categoryCreateDto: CategoryCreateDTO) {
    return this.http.post<ResultDTO<CategoryResponseDTO>>(this.baseUrl+"/", categoryCreateDto);
  }

  remove(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
