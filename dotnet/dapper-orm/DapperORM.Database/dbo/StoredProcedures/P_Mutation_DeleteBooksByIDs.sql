CREATE PROCEDURE [dbo].[P_Mutation_DeleteBooksByIDs]
	@ids dbo.[IntList] READONLY
AS
BEGIN TRANSACTION

	UPDATE Books

	SET [DeleteDate] = GETDATE()

	FROM Books

	WHERE Id IN (SELECT Id FROM @ids)

COMMIT