import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "dialogMarkdown", loadChildren: () => import("./dialog-markdown/dialog-markdown.module").then(m => m.DialogMarkdownModule)},
  { path: "", loadChildren: () => import("./home/home.module").then(m => m.HomeModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
