import {Injectable} from '@angular/core';
import {BaseService} from './base-service';
import {CommentResponseDTO} from '../_models/Comments/CommentResponseDTO';
import {CommentCreateDTO} from '../_models/Comments/CommentCreateDTO';
import {CommentUpdateDTO} from '../_models/Comments/CommentUpdateDTO';
import {HttpClient} from '@angular/common/http';
import {CommentResponseByIdDTO} from '../_models/Comments/CommentResponseByIdDTO';

@Injectable({
  providedIn: 'root'
})
export class CommentService extends BaseService<CommentResponseDTO, CommentCreateDTO, CommentUpdateDTO, CommentResponseByIdDTO> {
  protected baseUrl = "https://localhost:7000/api/comments";

  constructor(http: HttpClient) {
    super(http);
  }


}
