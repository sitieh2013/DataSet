DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `InsertEngineering` (in `@Name` varchar(255))
BEGIN
	insert engineering(Id) values(`@Name`);
END
$$ DELIMITER ;

