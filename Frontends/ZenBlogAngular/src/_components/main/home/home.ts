import {AfterViewInit, Component, OnInit} from '@angular/core';
import Swiper from 'swiper';
import {Autoplay, Navigation, Pagination} from 'swiper/modules';
import AOS from 'aos';
import {CategoryWithBlogsResponseDTO} from '../../../_models/Categories/CategoryWithBlogsResponseDTO';
import {BlogService} from '../../../_services/blog-service';
import {CategoryService} from '../../../_services/category-service';
import {RouterLink} from '@angular/router';
import {DatePipe, SlicePipe} from '@angular/common';
import {BlogLastCountResponseDTO} from '../../../_models/Blogs/BlogLastCountResponseDTO';


@Component({
  selector: 'home',
  templateUrl: './home.html',
  imports: [
    RouterLink,
    SlicePipe,
    DatePipe
  ],
  styleUrl: './home.css'
})
export class Home implements OnInit, AfterViewInit {
  swiper: any;
  isMobileMenuOpen = false;
  latestBlogs: BlogLastCountResponseDTO[] = [];
  categoriesWithBlogs: CategoryWithBlogsResponseDTO[] = [];

  constructor(private blogService: BlogService,
              private categoryService: CategoryService
  ) {

  }

  ngOnInit() {

    this.getLatest5Blogs();
    this.getCategoriesWithBlogs();

  }

  ngAfterViewInit() {
    // Remove preloader after view is initialized
    AOS.init({
      duration: 1000,
      easing: 'ease-in-out',
      once: true,
      mirror: false
    });

    // Initialize Swiper
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
    if (!navmenu) return;
    if (navmenu) {
      if (this.isMobileMenuOpen) {
        navmenu.classList.add('mobile-nav-active');
      } else {
        navmenu.classList.remove('mobile-nav-active');
      }
    }
  }

  getLatest5Blogs() {
    this.blogService.getLastCountBlogs().subscribe({
      next: result => this.latestBlogs = result.data ?? [],
      error: err => console.log(err)
    })
  }

  getCategoriesWithBlogs() {
    this.categoryService.getCategoriesWithBlogs().subscribe({
      next: result => this.categoriesWithBlogs = result.data ?? []
    })
  }


}
