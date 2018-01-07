DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `DeleteEngineering` (in `@Id` BIGINT)
BEGIN
	delete from engineering where Id=`@Id`;
END
$$ DELIMITER ;

