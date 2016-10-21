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

CREATE PROCEDURE dbo.usp_PersonFullName
AS
	SELECT
		CONCAT(p.FirstName, ' ', p.LastName) AS [FullName]
	FROM Persons p
GO

-- EXEC usp_PersonFullName

-- ====================================================================================================

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

CREATE PROCEDURE dbo.usp_CheckPersonsBalance (@balance MONEY)
AS
	SELECT
		CONCAT(p.FirstName, ' ', p.LastName) AS [FullName],
		a.Balance
	FROM Persons p
	INNER JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Balance > @balance
GO

-- EXEC usp_CheckPersonsBalance 3000

-- ====================================================================================================

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--    It should calculate and return the new sum.
--    Write a SELECT to test whether the function works as expected.

CREATE FUNCTION dbo.udf_CalculateInterestRate (@sum MONEY, @interestRate FLOAT, @numberOfMonths INT)
RETURNS MONEY
AS
BEGIN
	RETURN @sum * (1 + @interestRate / 12) * @numberOfMonths
END
GO

SELECT
	a.Balance,
	ROUND(dbo.udf_CalculateInterestRate(a.Balance, 0.6, 6), 2) AS [AdditionalMoney]
FROM Accounts a

-- ====================================================================================================

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--    It should take the AccountId and the interest rate as parameters.

CREATE PROCEDURE dbo.usp_FindPersonInterestRateForOneMonth (@accountId INT, @interesetRate FLOAT)
AS
	DECLARE @sum MONEY
	SELECT
		@sum = a.Balance
	FROM Accounts a
	WHERE a.Id = @accountId

	DECLARE @newSum MONEY

	SELECT
		@newSum = dbo.udf_CalculateInterestRate(@sum, @interesetRate, 1)

	SELECT
		p.FirstName,
		p.LastName,
		a.Balance,
		ROUND((@newSum), 2) AS [AdditonalMoney]
	FROM Persons p
	INNER JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Id = @accountId
GO

-- EXEC dbo.usp_FindPersonInterestRateForOneMonth	2, 0.5

-- ====================================================================================================

--5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.

CREATE PROCEDURE dbo.usp_WithdrawMoney (@accountId INT, @moneyToWithdraw MONEY)
AS
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @moneyToWithdraw
	WHERE Id = @accountId
	COMMIT TRANSACTION
GO

EXEC dbo.usp_WithdrawMoney 1, 2000

CREATE PROCEDURE dbo.usp_DepositMoney (@accountId INT, @moneyToDeposit MONEY)
AS
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance += @moneyToDeposit
	WHERE Id = @accountId;
	COMMIT TRANSACTION
GO

-- EXEC dbo.usp_DepositMoney 1, 1000

-- ====================================================================================================

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--    Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE dbo.Logs (
	Id INT IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts (Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL,
)
GO

CREATE TRIGGER dbo.trg_LogChanges
	ON dbo.Accounts
	FOR UPDATE
AS 
    INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT d.PersonID, d.Balance, ins.Balance
    FROM DELETED d, INSERTED ins
GO

-- EXEC dbo.usp_DepositMoney 1, 1000

-- ====================================================================================================