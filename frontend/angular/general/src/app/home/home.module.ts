import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeViewComponent } from './views/home/home.view.component';
import { HomeRoutingModule } from './home-routing.module';
import { Http404ViewComponent } from './views/http404/http404.view.component';

@NgModule({
  declarations: [
    HomeViewComponent,
    Http404ViewComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
  ]
})
export class HomeModule { }
