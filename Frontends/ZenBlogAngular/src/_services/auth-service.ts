import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginDTO} from '../_models/Auth/LoginDTO';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient, private router: Router) {
  }

  jwtHelper = new JwtHelperService();
  protected baseUrl = "https://localhost:7000/api/users";
  decodedToken: any;

  login(model: LoginDTO) {
    return this.http.post<any>(`${this.baseUrl}/login`, model);
  }

  decodeToken() {
    let token = localStorage.getItem('angular_token');
    this.decodedToken = this.jwtHelper.decodeToken(token);
    return this.decodedToken;
  }

  loggedIn() {
    const token = localStorage.getItem('angular_token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('angular_token');
    // noinspection JSIgnoredPromiseFromCall
    this.router.navigate(['']);
  }

}
