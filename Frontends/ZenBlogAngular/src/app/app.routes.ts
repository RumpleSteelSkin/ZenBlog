import {Routes} from '@angular/router';
import {MainLayout} from '../_components/_layouts/main-layout/main-layout';
import {Home} from '../_components/main/home/home';
import {AdminLayout} from '../_components/_layouts/admin-layout/admin-layout';
import {Category} from '../_components/admin/category/category';
import {Blog} from '../_components/admin/blog/blog';
import {Login} from '../_components/main/login/login';

export const routes: Routes = [
  //Main Routes
  {path: '', component: MainLayout, children: [{path: '', component: Home}, {path: 'login', component: Login}]},


  //Admin Routes
  {
    path: 'admin',
    component: AdminLayout,
    children: [{path: 'category', component: Category}, {path: 'blog', component: Blog},]
  },
];
