import { Component, NgModule } from '@angular/core';
import { DialogSlotModule } from '../dialog-slot.module';

import MicroModal from 'micromodal';

@Component({
  selector: 'dialog-slot-composition-cmp',
  templateUrl: "./dialog-slot-composition.html",
})
class DialogSlotCompositionComponent {

  dialogID = "dialog-hello-world";
  dialogTitle = "Hello World!"

  onOpenDialogClick = (e: MouseEvent) => {
    MicroModal.show(this.dialogID);
  };
}

@NgModule({
  declarations: [DialogSlotCompositionComponent],
  imports: [DialogSlotModule],
  bootstrap: [DialogSlotCompositionComponent]
})
export class DialogSlotCompositionModule {}
