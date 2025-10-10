import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BlogResponseDTO} from '../_models/Blogs/BlogResponseDTO';
import {BlogCreateDTO} from '../_models/Blogs/BlogCreateDTO';
import {BlogUpdateDTO} from '../_models/Blogs/BlogUpdateDTO';
import {BaseService} from './base-service';
import {BlogLastCountResponseDTO} from '../_models/Blogs/BlogLastCountResponseDTO';
import {ResultDTO} from '../_models/Base/ResultDTO';

@Injectable({
  providedIn: 'root'
})
export class BlogService extends BaseService<BlogResponseDTO, BlogCreateDTO, BlogUpdateDTO> {
  protected baseUrl = "https://localhost:7000/api/blogs";

  constructor(http: HttpClient) {
    super(http);
  }

  getLastCountBlogs() {
    return this.http.get<ResultDTO<BlogLastCountResponseDTO[]>>(`${this.baseUrl}/5`);
  }

}
