export interface IElementStyleStore {
  [k: string]: string,
}

export interface ICommonProps {
  data: unknown,
  styles?: ILinkedStyles,
}

export interface ILinkedStyles {
  components?: {
    [k: string]: IElementStyleStore
  },
  children?: {
    [k: string]: ILinkedStyles
  }
}
