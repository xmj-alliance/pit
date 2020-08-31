# config-injecter
Configs can be loaded and injected to a class that is in need.

## Prerequisites

### Dependencies

``` jsonc
{
  "dependencies": {
    "reflect-metadata": "^0.1.13",
    "typedi": "^0.8.0",
  },
  "devDependencies": {
    "typescript": "^4.0.2",
  }
}
```

### tsconfig

``` jsonc
{
  "compilerOptions": {
    "target": "es6",
    "emitDecoratorMetadata": true,
    "experimentalDecorators": true,
  }
}
```

## Test
- run `npm run test` or equivalent commands.