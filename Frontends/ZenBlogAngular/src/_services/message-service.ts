import {Injectable} from '@angular/core';
import {BaseService} from './base-service';
import {MessageResponseDTO} from '../_models/Messages/MessageResponseDTO';
import {MessageCreateDTO} from '../_models/Messages/MessageCreateDTO';
import {MessageUpdateDTO} from '../_models/Messages/MessageUpdateDTO';
import {MessageResponseByIdDTO} from '../_models/Messages/MessageResponseByIdDTO';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService extends BaseService<MessageResponseDTO, MessageCreateDTO, MessageUpdateDTO, MessageResponseByIdDTO> {
  protected override baseUrl = "https://localhost:7000/api/messages";

  constructor(http: HttpClient) {
    super(http);
  }
}
