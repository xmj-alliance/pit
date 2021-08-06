CREATE PROCEDURE [dbo].[P_Query_GetBooksByIDs]
	@ids dbo.[IntList] READONLY
AS

BEGIN

	SELECT *
	FROM Books
	WHERE Id IN (SELECT Id FROM @ids)
		AND DeleteDate IS NULL

END