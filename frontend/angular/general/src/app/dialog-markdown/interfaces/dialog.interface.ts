interface ICommomProps {
  children?: {
    [k: string]: ICommomProps
  },
}

export interface IDialogProps extends ICommomProps {
  id: string,
  title: string,
}