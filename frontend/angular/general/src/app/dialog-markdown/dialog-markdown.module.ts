import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarkdownDisplayComponent } from './components/markdown-display/markdown-display.component';
import { DialogSlotComponent } from './components/dialog-slot/dialog-slot.component';
import { DialogMarkdownViewComponent } from './views/dialog-markdown.view.component';
import { DialogMarkdownRoutingModule } from './dialog-markdown-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MarkdownDisplayComponent,
    DialogSlotComponent,
    DialogMarkdownViewComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    DialogMarkdownRoutingModule,
  ],
})
export class DialogMarkdownModule { }
