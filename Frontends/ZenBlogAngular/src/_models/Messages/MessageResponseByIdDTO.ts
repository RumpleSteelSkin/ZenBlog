import {BaseDTO} from "../Base/BaseDTO";

export class MessageResponseByIdDTO extends BaseDTO {
  name: string;
  email: string;
  subject: string;
  messageBody: string;
  isRead: boolean;
}
