import {BaseDTO} from '../Base/BaseDTO';
import {SafeResourceUrl} from '@angular/platform-browser';

export class ContactResponseDTO extends BaseDTO {
  address: string;
  email: string;
  phone: string;
  mapUrl: string;

  safeUrl?: SafeResourceUrl;
}


