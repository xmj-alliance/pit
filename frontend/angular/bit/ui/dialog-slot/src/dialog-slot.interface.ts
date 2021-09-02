interface IElementStyleRule {
  [index: string]: string,
}

export interface IDialogSlotProps {
  id: string,
  title: string,
  styles?: {
    slide?: IElementStyleRule,
    overlay?: IElementStyleRule,
    container?: IElementStyleRule,
    header?: IElementStyleRule,
    title?: IElementStyleRule,
    buttonClose?: IElementStyleRule,
    content?: IElementStyleRule,
  }
}