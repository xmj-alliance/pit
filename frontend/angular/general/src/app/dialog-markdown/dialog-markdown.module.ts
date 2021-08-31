import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DialogMarkdownViewComponent } from './views/dialog-markdown.view.component';
import { DialogMarkdownRoutingModule } from './dialog-markdown-routing.module';
import { FormsModule } from '@angular/forms';
import { DialogSlotModule } from '@xmj-alliance/pit-angular.ui.dialog-slot';
import { MarkdownDisplayModule } from '@xmj-alliance/pit-angular.ui.markdown-display';

@NgModule({
  declarations: [
    DialogMarkdownViewComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    DialogMarkdownRoutingModule,
    DialogSlotModule,
    MarkdownDisplayModule,
  ],
})
export class DialogMarkdownModule { }
