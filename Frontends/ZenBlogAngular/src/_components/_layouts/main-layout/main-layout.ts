// noinspection DuplicatedCode

import {AfterViewInit, Component, HostListener} from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {AuthService} from '../../../_services/auth-service';
import {Autoplay, Navigation, Pagination} from 'swiper/modules';
import Swiper from 'swiper';
import AOS from 'aos';
import {SocialService} from '../../../_services/social-service';
import {SocialResponseDTO} from '../../../_models/Socials/SocialResponseDTO';

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
export class MainLayout implements AfterViewInit {

  constructor(private authService: AuthService, private socialService: SocialService) {
    this.getSocials()
  }

  private swiper: Swiper | undefined;
  isMobileMenuOpen = false;
  socials: SocialResponseDTO[];

  getSocials() {
    this.socialService.get().subscribe({
      next: result => this.socials = result.data
    })
  }

  ngAfterViewInit() {
    AOS.init({
      duration: 1000,
      easing: 'ease-in-out',
      once: true,
      mirror: false
    });

    this.swiper = new Swiper('.init-swiper', {
      modules: [Navigation, Pagination, Autoplay],
      loop: false,
      speed: 600,
      autoplay: {
        delay: 5000,
        disableOnInteraction: false
      },
      slidesPerView: 'auto',
      centeredSlides: true,
      pagination: {
        el: '.swiper-pagination',
        type: 'bullets',
        clickable: true
      },
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
      }
    });


    const preloader = document.querySelector('#preloader');
    if (preloader) {
      preloader.remove();
    }
  }

  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    const navmenu = document.querySelector('#navmenu');
    if (navmenu) {
      if (this.isMobileMenuOpen) {
        navmenu.classList.add('mobile-nav-active');
      } else {
        navmenu.classList.remove('mobile-nav-active');
      }
    }
  }

  isScrolled = false;

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.isScrolled = window.scrollY > 100;
  }

  scrollToTop(event: Event) {
    event.preventDefault();
    window.scrollTo({top: 0, behavior: 'smooth'});
  }

  getFullName() {
    let decodedToken = this.authService.decodeToken();
    return decodedToken.fullName;
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
