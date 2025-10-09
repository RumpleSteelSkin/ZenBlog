import {Component} from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {AuthService} from '../../../_services/auth-service';

@Component({
  selector: 'main-layout',
  imports: [
    RouterOutlet,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.css'
})
export class MainLayout {
  constructor(private authService: AuthService) {
  }

  getFullName() {
    let decodedToken = this.authService.decodeToken();
    return decodedToken.fullName;
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
