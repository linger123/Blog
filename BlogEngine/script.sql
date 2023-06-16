
CREATE DATABASE BlogEngine CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci; 

DROP TABLE IF EXISTS  BlogEngine.Category;
CREATE TABLE IF NOT EXISTS BlogEngine.Category (
  `Id` MEDIUMINT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(150)  NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE = InnoDB;


DROP TABLE IF EXISTS BlogEngine.Post;
CREATE TABLE IF NOT EXISTS BlogEngine.Post (
  `Id` MEDIUMINT NOT NULL AUTO_INCREMENT,
  `CategoryId` MEDIUMINT NOT NULL,
  `Title` VARCHAR(150)  NOT NULL,
  `Content` TEXT NOT NULL,
  `PublicationDate` datetime NULL,
  PRIMARY KEY (`Id`),
  FOREIGN KEY (CategoryId) REFERENCES Category(Id)
) ENGINE = InnoDB;