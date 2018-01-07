DELIMITER $$
USE `databasetest`$$
CREATE PROCEDURE `DeleteAllEngineering` ()
BEGIN
	delete from engineering;
END
$$ DELIMITER ;


