import {Component, ViewEncapsulation} from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {AuthService} from '../../../_services/auth-service';
import {Dropdown} from 'bootstrap';

@Component({
  selector: 'admin-layout',
  imports: [
    RouterOutlet,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './admin-layout.html',
  styleUrl: './admin-layout.css',
  encapsulation: ViewEncapsulation.None
})
export class AdminLayout {
  constructor(private authService: AuthService) {
  }

  toggleDropdown() {
    const dropdownEl = document.getElementById('dropdownMenuButton');
    if (dropdownEl) {
      const dropdown = Dropdown.getOrCreateInstance(dropdownEl); // Bootstrap instance al
      dropdown.toggle(); // toggle et
    }
  }

  getUserName() {
    return this.authService.decodeToken().name;
  }

  logout() {
    this.authService.logout();
  }
}
