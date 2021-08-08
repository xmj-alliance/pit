CREATE PROCEDURE [dbo].[P_Query_GetBooksByDBNames]
	@dbnames dbo.[KeyList] READONLY
AS
BEGIN

	SELECT *
	FROM Books
	WHERE DBName IN (SELECT [Key] FROM @dbnames)
		AND DeleteDate IS NULL

END