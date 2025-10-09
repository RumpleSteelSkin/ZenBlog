import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginDTO} from '../_models/Auth/LoginDTO';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) {}

  protected baseUrl = "https://localhost:7000/api/users";

  login(model:LoginDTO){
    return this.http.post<any>(`${this.baseUrl}/login`, model);
  }

}
