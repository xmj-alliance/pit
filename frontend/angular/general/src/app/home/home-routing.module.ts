import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeViewComponent } from './views/home/home.view.component';
import { Http404ViewComponent } from './views/http404/http404.view.component';

const routes: Routes = [
  { path: "", redirectTo: "/home", pathMatch: 'full'},
  { path: "home", component: HomeViewComponent},
  { path: "**", component: Http404ViewComponent},
];

@NgModule({
  imports: [ RouterModule.forChild(routes)  ],
  exports: [ RouterModule ]
})
export class HomeRoutingModule {

}