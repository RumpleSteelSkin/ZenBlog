import {BaseDTO} from "../Base/BaseDTO";

export class ContactResponseByIdDTO extends BaseDTO {
  address: string;
  email: string;
  phone: string;
  mapUrl: string;
}
