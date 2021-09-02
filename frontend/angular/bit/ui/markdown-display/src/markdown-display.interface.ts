interface IElementStyleRule {
  [index: string]: string,
}

export interface IMarkdownDisplayProps {
  content: string,
  throttle: number,
  styles?: {
    article?: IElementStyleRule
  }
}