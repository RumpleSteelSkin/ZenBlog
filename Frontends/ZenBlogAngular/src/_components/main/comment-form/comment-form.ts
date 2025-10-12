import {Component} from '@angular/core';
import {CommentCreateDTO} from '../../../_models/Comments/CommentCreateDTO';
import {CommentService} from '../../../_services/comment-service';
import {ActivatedRoute} from '@angular/router';
import {FormsModule} from '@angular/forms';

declare const alertify: any;

@Component({
  selector: 'comment-form',
  imports: [
    FormsModule
  ],
  templateUrl: './comment-form.html',
  styleUrl: './comment-form.css'
})
export class CommentForm {
  newComment: CommentCreateDTO = new CommentCreateDTO();

  constructor(private commentService: CommentService,
              private route: ActivatedRoute
  ) {
  }


  createComment() {
    this.newComment.blogId = this.route.snapshot.params["id"];

    this.commentService.create(this.newComment).subscribe({
      error: result => {
        alertify.error("Comment Post Failed!")
        console.log(result)
        console.log(this.newComment);
      },
      complete: () => {
        alertify.success("Comment Posted!");
        location.reload();
      }
    })

  }


}
