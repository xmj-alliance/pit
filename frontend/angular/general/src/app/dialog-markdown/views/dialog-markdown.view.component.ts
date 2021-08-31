import { Component } from '@angular/core';
import { IDialogSlotProps } from '@xmj-alliance/pit-angular.ui.dialog-slot/dist/src/dialog-slot.interface';
import MicroModal from 'micromodal';

import testData from './test-data';

@Component({
  selector: 'app-dialog-markdown-view',
  templateUrl: './dialog-markdown.view.component.html',
  styleUrls: ['./dialog-markdown.view.component.scss']
})
export class DialogMarkdownViewComponent {

  dialogProps: IDialogSlotProps = {
    id: "dialog-markdown-display",
    title: "Markdown Display",
  };

  content = testData;
  throttle = 60;

  onOpenDialogClick = (e: MouseEvent) => {
    MicroModal.show(this.dialogProps.id);
  };

  constructor() { }

}
