CREATE SCHEMA `databasetest` ;

CREATE TABLE `databasetest`.`engineering` (
  `Id` BIGINT(20)  NOT NULL AUTO_INCREMENT COMMENT '' ,
  `Name` VARCHAR(255) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC)  COMMENT '');