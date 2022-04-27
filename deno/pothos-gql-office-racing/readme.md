# Pothos GQL Office Racing

This field test brings [Pothos GraphQL tool][Pothos] with [oak framework][oak].

## Dependencies

(todo)

## Running the app

Docker: TODO

Manually:

```shell
deno run --allow-net --import-map=deps.json src/app.ts
```

## Testing GraphQL Endpoints

(Import into Insomnia and test)

## Introduction

This feild test desmonstrates one approach to build a GraphQL "middle-end"
server in deno. It sets up CRUD services and controllers on top of
[oak framework][oak], accesses an imaginary data source, builds up GrapgQL
endpoints with [Pothos GraphQL tool][Pothos].

## Data model

The model used here is about office racing management. It has `Player`,
`Vehicle` and `Race`. The class diagram is shown as follows.

![dataModel](https://i.imgur.com/Dhd5grm.jpg)

https://online.visual-paradigm.com/community/share/pothos-gql-office-racing-x2jv4lc2j

Models are defined within `src/models`. The field test has also included the
GraphQL scalars extracted from `Urigo/graphql-scalars`.

## Model vs InputModel

GraphQL has object data type used in query, with input type used in mutation.

## Services

CRUD services for the field test is provided under `src/services`. They are
easily scalable for new models.

## Controllers

`APIController` opens `/api` route, which intends to show metadata, and to serve
as a rediness endpoint used by container health check systems.

`GraphController` is the main GraphQL endpoint `/gql`. It serves as a
minimalistic working GraphQL server that intergrates into `oak` routing system.

## Graph Building

(Limitation: cannot merge gql schema, so have to use this hacky way)

`SchemaBuilder.ts`: utility to create schema, making sure only 1 schema builder
instance presents.

`xxx.builder.ts`: Schema builder for each model. Defines gql object and input
type, builds query and mutation resolvers to be merged in the gql controller.

## Further development

Update lock file

```shell
deno cache --import-map=deps.json --unstable --lock=lock.json --lock-write src/app.ts
```

## Testings

```shell
deno test --import-map=./deps.json ./src/tests
```

## Side note

Notes about denoland library 404: https://github.com/hayes/pothos/issues/259

<!-- Refs -->

[Pothos]: https://pothos-graphql.dev/
[oak]: https://oakserver.github.io/oak/
