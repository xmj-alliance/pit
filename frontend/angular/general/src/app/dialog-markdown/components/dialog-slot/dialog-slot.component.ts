import { Component, Input, OnInit } from '@angular/core';
import MicroModal from 'micromodal';

import { IDialogProps } from '../../interfaces/dialog.interface';

@Component({
  selector: 'app-dialog-markdown-dialog-slot',
  templateUrl: './dialog-slot.component.html',
  styleUrls: ['./dialog-slot.component.scss']
})
export class DialogSlotComponent {

  dialogID = "";

  private _dialogProps: Partial<IDialogProps> = {};
  public get DialogProps(): Partial<IDialogProps> {
    return this._dialogProps;
  }

  @Input()
  public set DialogProps(v: Partial<IDialogProps>) {
    this._dialogProps = v;
    this.dialogID = v.id || `dialog-${ Math.random().toString() }`;
  }

  constructor() { }

}