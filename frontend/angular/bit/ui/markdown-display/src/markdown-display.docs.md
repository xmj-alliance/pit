---
labels: ['angular', 'typescript', 'markdown-display']
description: 'Renders Markdown content and displays it.'
---

# MarkdownDisplay documentation

## Usage

Import `MarkdownDisplayModule` into your application:

```ts
import { MarkdownDisplayModule } from './markdown-display.module';

// add it to your module imports
@NgModule({
  imports: [
    MarkdownDisplayModule
  ]
})
export class AppModule {}
```

Use `MarkdownDisplayComponent` in your templates:

```html
<markdown-display  [MarkdownDisplayProps]="{content: '\# hello world! \n This is a **Markdown** display component'}"></markdown-display>
```

Choose a style sheet for code syntax high-lighting, and add it to `angular.json` of your project root.

For example: 

``` diff
# angular.json
"projects": {
  "architect": {
    "build": {
      "styles": [
+        "node_modules/highlight.js/scss/github-dark.scss" // Or any other theme you wish
      ]
    }
  }
}

```

## API

Input:

``` typescript

interface IMarkdownDisplayProps {
  content: string,  // The text content to display
  throttle: number, // Maximum # of lines to process
  styles?: { // style overrides
    article?: IElementStyleRule
  }
}

```