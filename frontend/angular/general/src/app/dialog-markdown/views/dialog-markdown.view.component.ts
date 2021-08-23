import { Component, OnInit } from '@angular/core';
import MicroModal from 'micromodal';
import textMarkdown from ".././data/textMarkdown";
import { IDialogProps } from '../interfaces/dialog.interface';
import { ITextDisplayProps } from '../interfaces/text-display.interface';

@Component({
  selector: 'app-dialog-markdown-view',
  templateUrl: './dialog-markdown.view.component.html',
  styleUrls: ['./dialog-markdown.view.component.scss']
})
export class DialogMarkdownViewComponent implements OnInit {

  dialogProps: IDialogProps = {
    id: "dialog-markdown-display",
    title: "Markdown Display",
  };

  content = textMarkdown;
  throttle = 60;

  onOpenDialogClick = (e: MouseEvent) => {
    MicroModal.show(this.dialogProps.id);
  };

  constructor() { }

  ngOnInit(): void {
  }

}
