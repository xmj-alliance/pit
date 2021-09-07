export interface IElementStyleStore {
  [k: string]: string,
}

export interface ICommonProps {
  children?: {
    [k: string]: ICommonProps
  },
  styles?: {
    [k: string]: IElementStyleStore
  }
}