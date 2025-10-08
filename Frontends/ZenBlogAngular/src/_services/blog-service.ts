import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BlogResponseDTO} from '../_models/Blogs/BlogResponseDTO';
import {BlogCreateDTO} from '../_models/Blogs/BlogCreateDTO';
import {BlogUpdateDTO} from '../_models/Blogs/BlogUpdateDTO';
import {BaseService} from './base-service';

@Injectable({
  providedIn: 'root'
})
export class BlogService extends BaseService<BlogResponseDTO, BlogCreateDTO, BlogUpdateDTO> {
  protected baseUrl = "https://localhost:7000/api/blogs";

  constructor(http: HttpClient) {
    super(http);
  }
}
