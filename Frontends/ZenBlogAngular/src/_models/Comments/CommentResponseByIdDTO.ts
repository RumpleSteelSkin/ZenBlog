import {BaseDTO} from "../Base/BaseDTO";
import {SubCommentResponseDTO} from '../SubComments/SubCommentResponseDTO';

export class CommentResponseByIdDTO extends BaseDTO {
  firstName: string;
  lastName: string;
  email: string;
  body: string;
  blogId: string;
  subComments: SubCommentResponseDTO[];
}
