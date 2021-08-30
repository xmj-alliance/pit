import { Component, Input } from '@angular/core';
import hljs from 'highlight.js';
import * as marked from 'marked';
import { MarkedOptions } from 'marked';
import { IMarkdownDisplayProps } from './markdown-display.interface';

@Component({
  selector: 'markdown-display',
  templateUrl: './markdown-display.component.html',
  styleUrls: ['./markdown-display.component.scss']
})
export class MarkdownDisplayComponent {

  // Note: MarkDown throttles by line #

  displayContent = "";

  private _markdownDisplayProps: Partial<IMarkdownDisplayProps> = {};
  public get MarkdownDisplayProps(): Partial<IMarkdownDisplayProps> {
    return this._markdownDisplayProps;
  }

  markedOptions: MarkedOptions = {
    highlight: (code: any, lang: any) => {
      const renderLanguage = hljs.getLanguage(lang)? lang: "plaintext";
      return hljs.highlight(code, { language: renderLanguage }).value;
    },
    langPrefix: 'hljs language-',
  }

  @Input()
  public set MarkdownDisplayProps(v: Partial<IMarkdownDisplayProps>) {

    this._markdownDisplayProps = v;

    if (!v.content) {
      this.displayContent = "(No content to show...)";
      return;
    }

    if (v.throttle) {
      // include only first #throttle lines
      this.displayContent = marked(v.content.split("\n", v.throttle).join("\n"), this.markedOptions);
    } else {
      this.displayContent = marked(v.content, this.markedOptions);
    }

  }

  constructor() {}

}
