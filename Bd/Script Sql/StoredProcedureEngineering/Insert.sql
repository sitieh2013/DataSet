CREATE PROCEDURE InsertEngineering
	@Name varchar(255)
AS
	INSERT Engineering(Name) Values(@Name)
	RETURN @@Identity
