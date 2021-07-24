CREATE TABLE [dbo].[Readers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DBName] NVARCHAR(100) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [IsAdult] BIT NULL DEFAULT 0, 
    [Phone] NVARCHAR(50) NULL, 
    [Credit] DECIMAL NULL DEFAULT 0.0,
    CONSTRAINT UC_Readers UNIQUE (DBName)
)
