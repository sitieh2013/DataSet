DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `SelectAllEngineering` ()
BEGIN
	select engineering.* from engineering;
END
$$ DELIMITER ;


