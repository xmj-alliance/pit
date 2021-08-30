import { Component, NgModule, ViewEncapsulation } from '@angular/core';
import { MarkdownDisplayModule } from '../markdown-display.module';

import textMarkdown from "./markdown-display-test-data";

@Component({
  selector: 'markdown-display-composition-cmp',
  template: `MarkdownDisplay composition: <markdown-display [MarkdownDisplayProps]="{content: content}"></markdown-display>`,
  styleUrls: ['markdown-display.composition.scss'],
  encapsulation: ViewEncapsulation.None
})
class MarkdownDisplayCompositionComponent {
  content: string = textMarkdown;
}

@NgModule({
  declarations: [MarkdownDisplayCompositionComponent],
  imports: [MarkdownDisplayModule],
  bootstrap: [MarkdownDisplayCompositionComponent]
})
export class MarkdownDisplayCompositionModule {}
