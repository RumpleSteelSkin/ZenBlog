import {Component} from '@angular/core';
import {AuthService} from '../../../_services/auth-service';
import {LoginDTO} from '../../../_models/Auth/LoginDTO';
import {FormsModule} from '@angular/forms';

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
  constructor(private authService: AuthService) {
  }

  loginDto: LoginDTO = new LoginDTO();
  token: any;
  errors: any[] = [];

  login() {
    this.authService.login(this.loginDto).subscribe({
      next: result => {
        this.errors = [];
        this.token = result.data.token;
        alertify.success("Login Successful!");
      },
      error: err => {
        this.errors = err.error.errors;
        for (let i = 0; i < err.error.errors.length; i++) {
          alertify.error(err.error.errors[i].errorMessage);
        }
      }

    })
  }
}
