import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DialogMarkdownViewComponent } from './views/dialog-markdown.view.component';

const routes: Routes = [
  { path: "**", component: DialogMarkdownViewComponent},
];

@NgModule({
  imports: [ RouterModule.forChild(routes)  ],
  exports: [ RouterModule ]
})
export class DialogMarkdownRoutingModule {

}