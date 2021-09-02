---
labels: ['angular', 'typescript', 'dialog-slot']
description: 'A dialog with custom HTML slot'
---

# DialogSlot documentation

## Usage

Install `MicroModal`

``` bash

yarn add -D @types/microModal
# Or use npm install
```

Import `DialogSlotModule` into your application:

```ts
import { DialogSlotModule } from './dialog-slot.module';

// add it to your module imports
@NgModule({
  imports: [
    DialogSlotModule
  ]
})
export class AppModule {}
```

Use `DialogSlotComponent` in your templates:

```html
<!-- view.html -->
<dialog-slot [DialogProps]="{id: 'dialog-my-show', title: 'My Title'}">
  <main dialogContent>Yo! This is a <i>dialog</i> with plugged-in slot, with <b>Native</b> HTML support! </main>
</dialog-slot>
```

Add a button to handle dialog opening

``` html
<!-- view.component.html -->
<button (click)="onOpenDialogClick($event)">Open dialog</button>

```

``` typescript
import MicroModal from 'micromodal';

// view.component.ts
onOpenDialogClick = (e: MouseEvent) => {
  MicroModal.show('dialog-my-show');
};

```

## API

Input:

``` typescript

interface IDialogSlotProps {
  id: string, // The dialog ID used for Micromodal to track which dialog to open
  title: string, // The title shown on the dialog title bar.
  styles?: { // style overrides
    slide?: IElementStyleRule,
    overlay?: IElementStyleRule,
    container?: IElementStyleRule,
    header?: IElementStyleRule,
    title?: IElementStyleRule,
    buttonClose?: IElementStyleRule,
    content?: IElementStyleRule,
  }
}

```