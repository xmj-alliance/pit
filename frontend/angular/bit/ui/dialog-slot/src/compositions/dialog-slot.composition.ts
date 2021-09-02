import { Component, NgModule } from '@angular/core';
import { DialogSlotModule } from '../dialog-slot.module';

import MicroModal from 'micromodal';
import { IDialogSlotProps } from '../dialog-slot.interface';

@Component({
  selector: 'dialog-slot-composition-cmp',
  templateUrl: "./dialog-slot-composition.html",
  styleUrls: ["./dialog-slot-composition.scss"],
})
class DialogSlotCompositionComponent {

  dialogHelloProps: IDialogSlotProps = {
    id: "dialog-hello-world",
    title: "Hello World!",
  };

  terminalPrimary = "#00dd00";

  dialogTerminalProps: IDialogSlotProps = {
    id: "dialog-terminal",
    title: "System Self-destruction Routine",
    styles: {
      container: {
        "background-color": "rgba(0, 0, 0, 0.5)",
        border: `2px solid ${this.terminalPrimary}`,
        "max-width": "500px",
      },
      title: {
        color: this.terminalPrimary
      },
      buttonClose: {
        color: this.terminalPrimary
      },
      content: {
        color: this.terminalPrimary,
        display: "flex",
        "align-items": "center",
        "justify-content": "center",
      }
    }
  }

  openDialog = (id: string) => {
    MicroModal.show(id);
  };

  closeDialog = (id: string) => {
    MicroModal.close(id);
  };

  onOkayButtonClick = (e: MouseEvent) => {
    console.log("Okay, proceed next action.");
    this.closeDialog(this.dialogTerminalProps.id);
  };

  onCancelButtonClick = (e: MouseEvent) => {
    console.log("Cancel, operation has been cancelled");
    this.closeDialog(this.dialogTerminalProps.id);
  };

}

@NgModule({
  declarations: [DialogSlotCompositionComponent],
  imports: [DialogSlotModule],
  bootstrap: [DialogSlotCompositionComponent]
})
export class DialogSlotCompositionModule {}
