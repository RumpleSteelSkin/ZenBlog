import {BaseDTO} from "../Base/BaseDTO";

export class CommentResponseDTO extends BaseDTO {
  firstname: string;
  lastname: string;
  email: string;
  body: string;
  blogId: string;
}

