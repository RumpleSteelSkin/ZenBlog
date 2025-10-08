import {BaseDTO} from '../Base/BaseDTO';
import {CategoryResponseDTO} from '../Categories/CategoryResponseDTO';

export class BlogResponseDTO extends BaseDTO {
  title?: string;
  coverImage?: string;
  blogImage?: string;
  description?: string;
  categoryId: string;
  category?: CategoryResponseDTO;
  userId?: string;
}

