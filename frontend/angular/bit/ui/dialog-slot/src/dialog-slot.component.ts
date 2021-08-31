import { Component, Input } from '@angular/core';

import { IDialogSlotProps } from './dialog-slot.interface';

@Component({
  selector: 'dialog-slot',
  templateUrl: './dialog-slot.component.html',
  styleUrls: ['./dialog-slot.component.scss']
})
export class DialogSlotComponent {

  dialogID = "";

  private _dialogProps: Partial<IDialogSlotProps> = {};
  public get DialogProps(): Partial<IDialogSlotProps> {
    return this._dialogProps;
  }

  @Input()
  public set DialogProps(v: Partial<IDialogSlotProps>) {
    this._dialogProps = v;
    this.dialogID = v.id || `dialog-${ Math.random().toString() }`;
  }

  constructor() { }

}