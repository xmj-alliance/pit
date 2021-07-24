CREATE TABLE [dbo].[Record]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ReaderID] INT NOT NULL, 
    [BookID] INT NOT NULL, 
    [StartDate] DATETIME NULL DEFAULT CURRENT_TIMESTAMP, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [FK_Record_ToBooks] FOREIGN KEY ([BookID]) REFERENCES [Books]([Id]),
    CONSTRAINT [FK_Record_ToReaders] FOREIGN KEY ([ReaderID]) REFERENCES [Readers]([Id])
)
