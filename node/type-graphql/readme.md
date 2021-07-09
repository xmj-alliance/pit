# type-grpahql-cog
GraphQL Code-first approach implementation with TypeScript

The example models in this cog are based upon following class diagram:
![Class Diagram](https://i.imgur.com/cWapPxI.png)

## Features

The part where `type-graphql` works is located in the folder `src/controllers/graphs`. This cog has examples of:

- Basic queries and mutations

- Field Resolvers

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
- Import the [test JSON file](./doc/api-Insomnia.json) into your [Insomnia client](https://insomnia.rest/)
- You may also access the Graph playground at `serverAddress:3000/gql`. Refer to the docs on the right side.
- No unit tests provided since this cog is loacted at the controller level.