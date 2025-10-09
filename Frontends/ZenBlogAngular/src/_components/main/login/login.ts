import {Component} from '@angular/core';
import {AuthService} from '../../../_services/auth-service';
import {LoginDTO} from '../../../_models/Auth/LoginDTO';
import {FormsModule} from '@angular/forms';
import {Router} from '@angular/router';

declare const alertify: any;

@Component({
  selector: 'app-login',
  imports: [
    FormsModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  constructor(private authService: AuthService, private route: Router) {
  }

  loginDto: LoginDTO = new LoginDTO();
  token: any;
  errors: any[] = [];
  decodedToken: any;

  login() {
    this.authService.login(this.loginDto).subscribe({
      next: result => {
        this.errors = [];
        this.token = result.data.token;
        localStorage.setItem('angular_token', result.data.token);
        this.decodeToken();
        alertify.success("Login Successful Welcome " + this.decodedToken.fullName);
      },
      error: err => {
        this.errors = err.error.errors;
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      },
      complete: () => {
        // noinspection JSIgnoredPromiseFromCall
        this.route.navigate(['/admin/category']);
      }
    })
  }

  decodeToken() {
    this.decodedToken = this.authService.decodeToken();
  }

}
