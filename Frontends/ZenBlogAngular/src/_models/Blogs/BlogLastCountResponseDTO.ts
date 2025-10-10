import {BaseDTO} from "../Base/BaseDTO";
import {CategoryResponseDTO} from '../Categories/CategoryResponseDTO';

export class BlogLastCountResponseDTO extends BaseDTO {
  title?: string;
  coverImage?: string;
  blogImage?: string;
  description?: string;
  categoryId: string;
  category?: CategoryResponseDTO;
  userId?: string;
  user?: any;
}
