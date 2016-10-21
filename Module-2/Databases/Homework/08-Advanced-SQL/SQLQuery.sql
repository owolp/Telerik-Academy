-- ====================================================================================================

-- 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
-- Use a nested SELECT statement.

SELECT
	e.FirstName,
	e.LastName,
	e.Salary
FROM Employees e
WHERE e.Salary = (SELECT
		MIN(e2.Salary)
	FROM Employees e2)

-- ====================================================================================================

-- 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT
	e.FirstName,
	e.LastName,
	e.Salary
FROM Employees e
WHERE e.Salary < (SELECT
		MIN(e2.Salary) * 1.1
	FROM Employees e2)

-- ====================================================================================================

-- 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
-- Use a nested SELECT statement

SELECT
	e.FirstName + ' ' + e.LastName AS [FullName],
	e.Salary,
	d.Name AS [DepartmentName]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT
		MIN(e1.Salary)
	FROM Employees e1)

-- ====================================================================================================

-- 4. Write a SQL query to find the average salary in the department #1.

SELECT
	ROUND(AVG(e.Salary), 2) AS [AverageSalary]
FROM Employees e
WHERE e.DepartmentID = '1'

-- ====================================================================================================

-- 5. Write a SQL query to find the average salary in the "Sales" department.

SELECT
	ROUND(AVG(e.Salary), 2) AS [AverageSalary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- ====================================================================================================

-- 6. Write a SQL query to find the number of employees in the "Sales" department.

SELECT
	COUNT(*) AS [EmployeesCount]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- ====================================================================================================

-- 7. Write a SQL query to find the number of all employees that have manager.

SELECT
	COUNT(*) AS [EmployeesWithManager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

-- ====================================================================================================

-- 8. Write a SQL query to find the number of all employees that have no manager.

SELECT
	COUNT(*) AS [EmployeesWithManager]
FROM Employees e
WHERE e.ManagerID IS NULL

-- ====================================================================================================

-- 9. Write a SQL query to find all departments and the average salary for each of them.

SELECT
	d.Name,
	ROUND(AVG(e.Salary), 2) AS [AverageSalary]
FROM	Departments d,
		Employees e
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY AverageSalary DESC

-- ====================================================================================================

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT
	d.Name AS [DepartmentName],
	t.Name AS [TownName],
	COUNT(*) AS [EmployeesCount]
FROM	Departments d,
		Employees e,
		Towns t,
		Addresses a
WHERE e.DepartmentID = d.DepartmentID
AND e.AddressID = a.AddressID
AND a.TownID = t.TownID
GROUP BY	t.Name,
			d.Name

-- ====================================================================================================

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT
	m.FirstName + ' ' + m.LastName AS [ManagerName]
FROM	Employees e,
		Employees m
WHERE e.ManagerID = m.EmployeeID
GROUP BY	m.FirstName,
			m.LastName
HAVING COUNT(*) = 5

-- ====================================================================================================

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [ManagerFullName]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

-- Managers without direct reports

SELECT
	m.FirstName + ' ' + m.LastName AS [ManagerFullName],
	ISNULL(e.FirstName + ' ' + e.LastName, 'no reports') AS [EmployeeFullName]
FROM Employees m
LEFT OUTER JOIN Employees e
	ON e.ManagerID = m.EmployeeID
ORDER BY M.FirstName

-- ====================================================================================================

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT
	e.FirstName,
	e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5
ORDER BY e.LastName

-- ====================================================================================================

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".

SELECT
	FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff')

-- ====================================================================================================

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames.
-- Define a check constraint to ensure the password is at least 5 characters long.


CREATE TABLE dbo.Users (
	Id INT IDENTITY,
	Username NVARCHAR(50) NOT NULL UNIQUE,
	Password NVARCHAR(50) NOT NULL CHECK (LEN(Password) > 5),
	Fullname NVARCHAR(50) NOT NULL,
	LastLogin SMALLDATETIME NOT NULL,
	CONSTRAINT PK_Users_Id PRIMARY KEY (Id)
)
GO

-- ====================================================================================================

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. 

CREATE VIEW [LoggedUsersForTheDay]
AS
SELECT
	u.Fullname,
	u.LastLogin
FROM Users u
WHERE u.LastLogin BETWEEN '2016-10-19 00:00:00' AND '2016-10-19 23:59:59'

--

SELECT
	*
FROM LoggedUsersForTheDay luftd

-- ====================================================================================================

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
-- Define primary key and identity column.

CREATE TABLE dbo.Groups (
	Id INT IDENTITY,
	Name NVARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_Groups_Id PRIMARY KEY (Id)
)
GO

-- ====================================================================================================

-- 18. Write a SQL statement to add a column GroupID to the table Users.
-- Fill some data in this new column and as well in the `Groups table.
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE dbo.Users
ADD GroupId INT NOT NULL
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY (GroupId)
REFERENCES Groups (Id)
GO

-- ====================================================================================================

-- 19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups
	VALUES ('Group1'),
	('Group2'),
	('Group3'),
	('Group4'),
	('Group5')
GO

INSERT INTO Users
	VALUES ('username1', 'password1', 'fullname1', '2016-10-20 01:00:00', '1'),
	('username2', 'password2', 'fullname2', '2016-10-20 02:00:00', '2'),
	('username3', 'password3', 'fullname3', '2016-10-20 03:00:00', '3'),
	('username4', 'password4', 'fullname4', '2016-10-20 04:00:00', '4'),
	('username5', 'password5', 'fullname5', '2016-10-20 05:00:00', '5')
GO

-- ====================================================================================================

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET	Username = 'usernameUpdate',
	Password = 'passwordUpdate',
	Fullname = 'fullnameUpdate',
	LastLogin = GETDATE(),
	GroupId = '1'
WHERE Id = 3
GO

UPDATE Groups
SET Name = 'groupUpdate'
WHERE Id = 1
GO

-- ====================================================================================================

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE Users
WHERE Username LIKE '%update%'
GO

-- ====================================================================================================

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name.
-- For username use the first letter of the first name + the last name (in lowercase).
-- Use the same for the password, and NULL for last login time.


CREATE TABLE dbo.Employees (
	Id INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Employees_Id PRIMARY KEY (Id)
)
GO

INSERT INTO Users (Username, Fullname, Password)
		(SELECT
			LOWER(CONCAT(FirstName, LastName)),
			CONCAT(FirstName, ' ', LastName),
			LOWER(CONCAT(FirstName, LastName))
		FROM Employees)
GO
-- ====================================================================================================

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

ALTER TABLE Users
ALTER COLUMN Password NVARCHAR(50) NULL
GO

UPDATE Users
SET Password = NULL
WHERE DATEDIFF(DAY, LastLogin, '2010-10-10 00:00:00') < 0
GO

-- ====================================================================================================

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE Users
WHERE Password IS NULL

-- ====================================================================================================

-- 25. Write a SQL query to display the average employee salary by department and job title.
SELECT
	d.Name AS [DepartmentName],
	e.JobTitle AS [JobTitle],
	ROUND(AVG(e.Salary), 2) AS [AverageSalaryByDepartment]
FROM	Departments d,
		Employees e
WHERE e.DepartmentID = d.DepartmentID
GROUP BY	d.Name,
			e.JobTitle
ORDER BY AverageSalaryByDepartment

-- ====================================================================================================

-- 26. Write a SQL query to display the minimal employee salary by department and job title along with
-- the name of some of the employees that take it.

SELECT
	MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [EmployeeName],
	e.JobTitle,
	d.Name AS [DepartmentName],
	ROUND(MIN(e.Salary), 2) AS [MinSalary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	d.Name,
			e.JobTitle,
			e.Salary
ORDER BY MinSalary
GO

-- ====================================================================================================

-- 27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1
	t.Name,
	COUNT(e.EmployeeID) AS [EmployeesCount]
FROM Employees e
INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
INNER JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY EmployeesCount DESC
GO

-- ====================================================================================================

-- 28. Write a SQL query to display the number of managers from each town.

SELECT
	t.Name,
	COUNT(e.EmployeeID) AS [NumberOfManagers]
FROM Employees e
INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
INNER JOIN Towns t
	ON a.TownID = t.TownID
INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID = m.EmployeeID
GROUP BY t.Name
ORDER BY NumberOfManagers DESC

-- ====================================================================================================

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
-- Don't forget to define identity, primary key and appropriate foreign key.
-- Issue few SQL statements to insert, update and delete of some data in the table.
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
-- For each change keep the old record data, the new record data and the command (insert / update / delete).


-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================