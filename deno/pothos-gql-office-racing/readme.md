# Pothos GQL Office Racing

This field test brings [Pothos GraphQL tool][Pothos] with [oak framework][oak].

## Data model

![dataModel](https://i.imgur.com/Dhd5grm.jpg)

https://online.visual-paradigm.com/community/share/pothos-gql-office-racing-x2jv4lc2j

## Dependencies

(todo)

## Further development

Update lock file

```shell
deno cache --import-map=deps.json --unstable --lock=lock.json --lock-write src/app.ts
```

## Testings

```shell
deno test --allow-all --import-map=./deps.json ./src/tests
```

## Side note

https://github.com/hayes/pothos/issues/259

<!-- Refs -->

[Pothos]: https://pothos-graphql.dev/
[oak]: https://oakserver.github.io/oak/
