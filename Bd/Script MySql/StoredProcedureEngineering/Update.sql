DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `UpdateEngineering` (in `@Name` varchar(255), `@Id` BIGINT)
BEGIN
	update engineering set Name = `@Name` where Id = `@Id`;
END
$$ DELIMITER ;


