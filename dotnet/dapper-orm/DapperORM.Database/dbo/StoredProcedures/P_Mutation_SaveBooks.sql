CREATE PROCEDURE [dbo].[P_Mutation_SaveBooks]
	@inputBooks dbo.[InputBooks] READONLY
AS
BEGIN TRANSACTION

	-- default values
	DECLARE @defaultRating FLOAT = 0.0
	DECLARE @defaultUpdateDate DATETIME = GETDATE()

	-- select books without id, then do insert
	INSERT INTO Books
	SELECT 
		[DBName],
		[Title],
		ISNULL([Rating], @defaultRating),
		ISNULL([UpdateDate], @defaultUpdateDate),
		[DeleteDate]
	FROM @inputBooks
	WHERE Id is null

	-- select books with id, then do replace (update)
	UPDATE Books

	SET [DBName] = inputBooks.[DBName],
		[Title] = inputBooks.[Title],
		[Rating] = ISNULL(inputBooks.[Rating], @defaultRating),
		[UpdateDate] = ISNULL(inputBooks.[UpdateDate], @defaultUpdateDate),
		[DeleteDate] = inputBooks.[DeleteDate]

	FROM Books targetBooks
		INNER JOIN @inputBooks inputBooks ON inputBooks.Id = targetBooks.Id

COMMIT