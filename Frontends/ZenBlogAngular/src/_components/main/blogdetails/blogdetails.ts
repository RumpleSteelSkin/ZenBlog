import {Component} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {BlogResponseDTO} from '../../../_models/Blogs/BlogResponseDTO';
import {CommentCreateDTO} from '../../../_models/Comments/CommentCreateDTO';
import {BlogService} from '../../../_services/blog-service';
import {DatePipe} from '@angular/common';
import {BlogResponseByIdDTO} from '../../../_models/Blogs/BlogResponseByIdDTO';

@Component({
  selector: 'app-blogdetails',
  templateUrl: './blogdetails.html',
  imports: [
    DatePipe
  ],
  styleUrl: './blogdetails.css'
})

export class Blogdetails {
  blog: BlogResponseByIdDTO;
  latestBlogs: BlogResponseDTO[];
  newComment: CommentCreateDTO = new CommentCreateDTO();


  constructor(private blogService: BlogService,
              private route: ActivatedRoute
  ) {
    this.getBlogById();
    this.getLatestBlogs();
  }


  getBlogById() {
    this.blogService.getById(this.route.snapshot.params["id"]).subscribe({
      next: result => this.blog = result.data
    })
  }

  getLatestBlogs() {
    this.blogService.getLastCountBlogs().subscribe({
      next: result => this.latestBlogs = result.data
    })
  }

  postComment() {
    this.newComment.blogId = this.route.snapshot.params["id"];
  }

}
