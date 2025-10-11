import {BaseDTO} from "../Base/BaseDTO";
import {CategoryResponseDTO} from "../Categories/CategoryResponseDTO";
import {CommentResponseDTO} from "../Comments/CommentResponseDTO";

export class BlogResponseByIdDTO extends BaseDTO {
  title?: string;
  coverImage?: string;
  blogImage?: string;
  description?: string;
  categoryId: string;
  category?: CategoryResponseDTO;
  userId?: string;
  user?: any;
  comments?: CommentResponseDTO[];
}
