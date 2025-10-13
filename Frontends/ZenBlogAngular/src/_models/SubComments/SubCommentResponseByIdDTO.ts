import {BaseDTO} from "../Base/BaseDTO";
import {SubCommentResponseDTO} from './SubCommentResponseDTO';

export class SubCommentResponseByIdDTO extends BaseDTO {
  firstName: string;
  lastName: string;
  email: string;
  body: string;
  commentDate: string;
  commentId: string;
  subComments: SubCommentResponseDTO[];
}
