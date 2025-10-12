import {BaseDTO} from '../Base/BaseDTO';

export class MessageResponseDTO extends BaseDTO {
  name: string;
  email: string;
  subject: string;
  messageBody: string;
  isRead: boolean;
}

