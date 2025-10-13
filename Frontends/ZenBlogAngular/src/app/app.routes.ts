import {Routes} from '@angular/router';
import {MainLayout} from '../_components/_layouts/main-layout/main-layout';
import {Home} from '../_components/main/home/home';
import {AdminLayout} from '../_components/_layouts/admin-layout/admin-layout';
import {Category} from '../_components/admin/category/category';
import {Blog} from '../_components/admin/blog/blog';
import {Login} from '../_components/main/login/login';
import {AuthGuard} from '../_guards/auth-guard';
import {Blogdetails} from '../_components/main/blogdetails/blogdetails';
import {ContactMain} from '../_components/main/contact-main/contact-main';
import {Comment} from '../_components/admin/comment/comment';


export const routes: Routes = [
  //Main Routes
  {
    path: '', component: MainLayout, children:
      [
        {path: '', component: Home},
        {path: 'login', component: Login},
        {path: 'blogdetails/:id', component: Blogdetails},
        {path: 'contact', component: ContactMain},
      ]
  },


  //Admin Routes
  {
    path: 'admin',
    component: AdminLayout,
    canActivate: [AuthGuard],
    children:
      [
        {path: 'category', component: Category, canActivate: [AuthGuard]},
        {path: 'blog', component: Blog, canActivate: [AuthGuard]},
        {path: 'comment', component: Comment, canActivate: [AuthGuard]},
      ]
  },
];
