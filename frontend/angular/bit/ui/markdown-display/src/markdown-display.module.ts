import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MarkdownDisplayComponent } from './markdown-display.component';

@NgModule({
  declarations: [
    MarkdownDisplayComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MarkdownDisplayComponent
  ]
})
export class MarkdownDisplayModule {}
