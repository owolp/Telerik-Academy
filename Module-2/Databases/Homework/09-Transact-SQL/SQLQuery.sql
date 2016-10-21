-- ====================================================================================================

-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--    Insert few records for testing.
--    Write a stored procedure that selects the full names of all persons.

CREATE TABLE dbo.Persons (
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE dbo.Accounts (
	Id INT IDENTITY PRIMARY KEY,
	PersonId INT NOT NULL FOREIGN KEY REFERENCES Persons (Id),
	Balance MONEY NOT NULL,
)
GO

INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES ('First1', 'Last1', '111'),
	('First2', 'Last2', '222'),
	('First3', 'Last3', '333'),
	('First4', 'Last4', '444'),
	('First5', 'Last5', '555')
GO

INSERT INTO Accounts (PersonId, Balance)
	VALUES (1, 1000),
	(2, 2000),
	(3, 3000),
	(4, 4000),
	(5, 5000)
GO

CREATE PROCEDURE dbo.PersonFullName
AS
	SELECT
	CONCAT(p.FirstName, ' ', p.LastName) AS [FullName]
	FROM Persons p
GO

-- ====================================================================================================

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.



-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================