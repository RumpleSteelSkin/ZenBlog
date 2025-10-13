import {BaseDTO} from '../Base/BaseDTO';

export class SubCommentResponseDTO extends BaseDTO {
  firstName: string;
  lastName: string;
  email: string;
  body: string;
  commentDate: string;
  commentId: string;
}

