-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`universitys`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`universitys` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`facultys`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`facultys` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `universityId` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Facultys_Universitys_idx` (`universityId` ASC),
  CONSTRAINT `FK_Facultys_Universitys`
    FOREIGN KEY (`universityId`)
    REFERENCES `university`.`universitys` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`departments` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `facultyId` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Departments_Facultys_idx` (`facultyId` ASC),
  CONSTRAINT `FK_Departments_Facultys`
    FOREIGN KEY (`facultyId`)
    REFERENCES `university`.`facultys` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`proffesors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`proffesors` (
  `id` INT(11) NOT NULL,
  `firstName` VARCHAR(50) NOT NULL,
  `lastName` VARCHAR(50) NOT NULL,
  `departmentId` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Professors_Departments_idx` (`departmentId` ASC),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`departmentId`)
    REFERENCES `university`.`departments` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`courses` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `proffesorId` INT(11) NOT NULL,
  `departmentId` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Courses_Professors_idx` (`proffesorId` ASC),
  INDEX `FK_Courses_Departments_idx` (`departmentId` ASC),
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`departmentId`)
    REFERENCES `university`.`departments` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`proffesorId`)
    REFERENCES `university`.`proffesors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`titles` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`proffesorstitles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`proffesorstitles` (
  `proffesorId` INT(11) NOT NULL,
  `titleId` INT(11) NOT NULL,
  INDEX `FK_ProffesorsTitles_Professors_idx` (`proffesorId` ASC),
  INDEX `FK_ProffesorsTitles_Titles_idx` (`titleId` ASC),
  CONSTRAINT `FK_ProffesorsTitles_Professors`
    FOREIGN KEY (`proffesorId`)
    REFERENCES `university`.`proffesors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProffesorsTitles_Titles`
    FOREIGN KEY (`titleId`)
    REFERENCES `university`.`titles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`students` (
  `id` INT(11) NOT NULL,
  `firstName` VARCHAR(50) NOT NULL,
  `lastName` VARCHAR(50) NOT NULL,
  `facultyNumber` VARCHAR(50) NOT NULL,
  `facultyId` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_Students_Facultys_idx` (`facultyId` ASC),
  CONSTRAINT `FK_Students_Facultys`
    FOREIGN KEY (`facultyId`)
    REFERENCES `university`.`facultys` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`studentscourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`studentscourses` (
  `studentId` INT(11) NOT NULL,
  `courseId` INT(11) NOT NULL,
  INDEX `FK_StudentsCourses_Courses_idx` (`courseId` ASC),
  INDEX `FK_StudentsCourses_Students_idx` (`studentId` ASC),
  CONSTRAINT `FK_StudentsCourses_Courses`
    FOREIGN KEY (`courseId`)
    REFERENCES `university`.`courses` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Students`
    FOREIGN KEY (`studentId`)
    REFERENCES `university`.`students` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
