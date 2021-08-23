import { Component, Input, OnInit } from '@angular/core';
import * as marked from 'marked';
import { ITextDisplayProps } from '../../interfaces/text-display.interface';

@Component({
  selector: 'app-dialog-markdown-markdown-display',
  templateUrl: './markdown-display.component.html',
  styleUrls: ['./markdown-display.component.scss']
})
export class MarkdownDisplayComponent implements OnInit {

  // Note: MarkDown throttles by line #

  displayContent = "";

  private _markdownDisplayProps: Partial<ITextDisplayProps> = {};
  public get MarkdownDisplayProps(): Partial<ITextDisplayProps> {
    return this._markdownDisplayProps;
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
      this.displayContent = marked(v.content.split("\n", v.throttle).join("\n"));
    } else {
      this.displayContent = marked(v.content);
    }

  }
  

  constructor() { }

  ngOnInit(): void {
  }

}