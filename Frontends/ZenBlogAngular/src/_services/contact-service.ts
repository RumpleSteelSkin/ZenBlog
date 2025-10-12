import {Injectable} from '@angular/core';
import {BaseService} from './base-service';
import {ContactResponseDTO} from '../_models/Contacts/ContactResponseDTO';
import {ContactCreateDTO} from '../_models/Contacts/ContactCreateDTO';
import {ContactUpdateDTO} from '../_models/Contacts/ContactUpdateDTO';
import {ContactResponseByIdDTO} from '../_models/Contacts/ContactResponseByIdDTO';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService<ContactResponseDTO, ContactCreateDTO, ContactUpdateDTO, ContactResponseByIdDTO> {
  protected override baseUrl = "https://localhost:7000/api/contactinfos";

  constructor(http: HttpClient) {
    super(http);
  }
}
