DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `SelectEngineering` (in `@Id` BIGINT)
BEGIN
	select engineering.* from engineering where Id=`@Id`;
END
$$ DELIMITER ;


