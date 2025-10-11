import {BaseDTO} from "../Base/BaseDTO";

export class CommentResponseByIdDTO extends BaseDTO {
  firstname: string;
  lastname: string;
  email: string;
  body: string;
  blogId: string;
}
