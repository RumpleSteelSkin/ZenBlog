import {Component, OnInit, signal} from '@angular/core';
import {RouterOutlet} from '@angular/router';

declare const alertify: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [
    RouterOutlet
  ],
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected readonly title = signal('ZenBlogAngular');

  ngOnInit() {
    alertify.set('notifier', 'position', 'top-right');
  }
}
