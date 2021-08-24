# Dialog Markdown Pit

## Dependencies

``` jsonc
  "dependencies": {
    "highlight.js": "^11.2.0",
    "marked": "^3.0.1",
    "micromodal": "^0.4.6",
  },
  "devDependencies": {
    "@types/marked": "^2.0.4",
    "@types/micromodal": "^0.3.3",
  }
```

Changes to `angular.json`:

``` diff

"projects": {
  "architect": {
    "build": {
      "styles": [
+        "node_modules/highlight.js/scss/github-dark.scss" // Or any theme you wish
      ]
    }
  }
}

```
