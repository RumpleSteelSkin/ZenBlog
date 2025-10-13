import {BaseDTO} from "../Base/BaseDTO";

export class CommentResponseByIdDTO extends BaseDTO {
  firstName: string;
  lastName: string;
  email: string;
  body: string;
  blogId: string;
}
