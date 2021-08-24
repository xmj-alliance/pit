import { Component, Input } from '@angular/core';
import hljs from 'highlight.js';
import * as marked from 'marked';
import { MarkedOptions } from 'marked';
import { ITextDisplayProps } from '../../interfaces/text-display.interface';

@Component({
  selector: 'app-dialog-markdown-markdown-display',
  templateUrl: './markdown-display.component.html',
  styleUrls: ['./markdown-display.component.scss']
})
export class MarkdownDisplayComponent {

  // Note: MarkDown throttles by line #

  displayContent = "";

  private _markdownDisplayProps: Partial<ITextDisplayProps> = {};
  public get MarkdownDisplayProps(): Partial<ITextDisplayProps> {
    return this._markdownDisplayProps;
  }

  markedOptions: MarkedOptions = {
    highlight: (code, lang) => {
      const renderLanguage = hljs.getLanguage(lang)? lang: "plaintext";
      return hljs.highlight(code, { language: renderLanguage }).value;
    },
    langPrefix: 'hljs language-',
  }

  @Input()
  public set MarkdownDisplayProps(v: Partial<ITextDisplayProps>) {

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
  
  constructor() { }

}