import {Injectable} from '@angular/core';
import {BaseService} from './base-service';
import {SubCommentResponseDTO} from '../_models/SubComments/SubCommentResponseDTO';
import {SubCommentCreateDTO} from '../_models/SubComments/SubCommentCreateDTO';
import {SubCommentUpdateDTO} from '../_models/SubComments/SubCommentUpdateDTO';
import {SubCommentResponseByIdDTO} from '../_models/SubComments/SubCommentResponseByIdDTO';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SubCommentService extends BaseService<SubCommentResponseDTO, SubCommentCreateDTO, SubCommentUpdateDTO, SubCommentResponseByIdDTO> {
  protected override baseUrl = "https://localhost:7000/api/subcomments";

  constructor(http: HttpClient) {
    super(http);
  }
}
