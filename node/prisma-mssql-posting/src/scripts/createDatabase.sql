IF NOT EXISTS (
  SELECT name
  FROM sys.databases
  WHERE name = N'prisma-mssql-posting-dev'
)
  CREATE DATABASE [prisma-mssql-posting-dev];
GO
IF SERVERPROPERTY('ProductVersion') > '12'
  ALTER DATABASE [prisma-mssql-posting-dev]
  SET QUERY_STORE=ON;
GO
