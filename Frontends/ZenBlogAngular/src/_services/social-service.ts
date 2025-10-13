import {Injectable} from '@angular/core';
import {BaseService} from './base-service';
import {SocialResponseDTO} from '../_models/Socials/SocialResponseDTO';
import {SocialCreateDTO} from '../_models/Socials/SocialCreateDTO';
import {SocialUpdateDTO} from '../_models/Socials/SocialUpdateDTO';
import {SocialResponseByIdDTO} from '../_models/Socials/SocialResponseByIdDTO';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SocialService extends BaseService<SocialResponseDTO, SocialCreateDTO, SocialUpdateDTO, SocialResponseByIdDTO> {
  protected override baseUrl = "https://localhost:7000/api/socials";

  constructor(http: HttpClient) {
    super(http);
  }

}
