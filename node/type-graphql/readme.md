# type-grpahql
GraphQL Code-first approach implementation with TypeScript

<!-- The example models in this cog are based upon following class diagram:
![Class Diagram](./doc/mongo-class-model.png) -->

## Prerequisites

### Dependencies

``` jsonc
{
  "dependencies": {
    "class-validator": "^0.13.1",
    "graphql": "^15.5.1",
    "reflect-metadata": "^0.1.13",
    "type-graphql": "^1.1.1"
  },
  "devDependencies": {
    "typescript": "^4.3.4"
  }
}
```

### tsconfig

``` jsonc
{
  "compilerOptions": {
    "target": "es2018",
    "emitDecoratorMetadata": true,
    "experimentalDecorators": true,
    "lib": ["es2018", "esnext.asynciterable"]
  }
}
```

## Test
- Import the test json file into your Insomnia client
- You may also access the Graph playground at `serverAddress:3000/gql`
- No unit tests provided since this cog is loacted at the controller level.