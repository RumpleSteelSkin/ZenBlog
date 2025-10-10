import {BaseDTO} from "../Base/BaseDTO";
import {BlogResponseDTO} from "../Blogs/BlogResponseDTO";

export class CategoryWithBlogsResponseDTO extends BaseDTO {
  name?: string;
  blogs?: BlogResponseDTO[];
}
