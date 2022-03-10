# Prisma MSSQL Posting pit

The pit demonstrates CRUD using `primsa` on mssql

## Dependencies

You need to setup SQL Server (2019) properly. Either install on a windows machine or deploy a docker container.

This pit uses `pnpm` package manager.

Library:

``` jsonc
  // package.json

  "devDependencies": {
    "@types/jest": "^27.4.1",
    "@types/node": "^17.0.21",
    "jest": "^27.5.1",
    "prisma": "^3.10.0",
    "ts-jest": "^27.1.3",
    "typescript": "^4.6.2"
  },
  "dependencies": {
    "@prisma/client": "^3.10.0"
  }

```

``` jsonc
// tsconfig.json
{
  "compilerOptions": {
    "sourceMap": true,
    "outDir": "dist",
    "strict": true,
    "lib": [
      "esnext"
    ],
    "esModuleInterop": true,
    // below is optional, it adds path alias definitions.
    // -->
    "baseUrl": ".",
    "paths": {
      "prisma/*": [
        "prisma/*"
      ],
      "src/*": [
        "src/*"
      ],
    }
    // <-- optional
  }
}

```

## Getting started:

- Create database

  Run [db creation script](src/scripts/createDatabase.sql) on MSSQL.

- (Optional) Import sample data

  Run [db seeding script](src/scripts/insertData.sql) on MSSQL.

  Note: Database will be cleared after each test running.

- Create `.env` file in root folder and specify your connection string within.

  ``` conf
  DATABASE_URL="sqlserver://[dbserverhost]:[port];database=[prisma-mssql-posting-dev];user=[dbuser];password=[dbUserPassword];encrypt=true;trustServerCertificate=true;"
  ```

- Grab node modules

  ``` shell
  pnpm install 
  ```

  Note: If `pnpm` is not yet installed, check out [pnpm Installation Guide](https://pnpm.io/installation).

- Deploy migration

  ``` shell
  npx prisma migrate deploy
  ```

- Generate typings

  ``` shell
  npx prisma generate
  ```

## Testing

This pit uses Jest testing framework.

``` shell
pnpm test
```

## Further schema development

Check out [Prisma Set-up Guide for MSSQL](https://www.prisma.io/docs/getting-started/setup-prisma/start-from-scratch/relational-databases/using-prisma-migrate-typescript-sqlserver)
