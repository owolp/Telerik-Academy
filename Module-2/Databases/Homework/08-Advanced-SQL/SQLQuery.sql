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

CREATE TABLE dbo.Users (
	Id INT IDENTITY,
	Username NVARCHAR(50) NOT NULL,
	Password NVARCHAR(50) NOT NULL,
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

CREATE TABLE dbo.Groups (
	Id INT IDENTITY,
	Name NVARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_Groups_Id PRIMARY KEY (Id)
)
GO

-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================