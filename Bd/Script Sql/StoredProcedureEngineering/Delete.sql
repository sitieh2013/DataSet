CREATE PROCEDURE DeleteEngineering
	@Id BIGINT
AS
	Delete from Engineering where Id=@Id
	RETURN

