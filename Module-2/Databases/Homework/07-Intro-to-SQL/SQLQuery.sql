-- ====================================================================================================

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT
	d.Name AS [DepartmentName],
	e.FirstName + ' ' + e.LastName AS [ManagerName]
FROM Departments d
INNER JOIN Employees e
	ON d.ManagerID = e.EmployeeID

-- OR

SELECT
	d.Name AS [DepartmentName],
	e.FirstName + ' ' + e.LastName AS [ManagerName]
FROM	Departments d,
		Employees e
WHERE d.ManagerID = e.EmployeeID

-- ====================================================================================================

-- 5. Write a SQL query to find all department names.

SELECT
	d.Name AS [DepartmentName]
FROM Departments d

-- ====================================================================================================

-- 6. Write a SQL query to find the salary of each employee.

SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	e.Salary
FROM Employees e

-- ====================================================================================================

-- 7. Write a SQL to find the full name of each employee.
SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName]
FROM Employees e

-- ====================================================================================================

-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
-- The produced column should be named "Full Email Addresses".

SELECT
	e.FirstName + '.' + e.LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees e

-- ====================================================================================================

-- 9. Write a SQL query to find all different employee salaries.

SELECT DISTINCT
	e.Salary
FROM Employees e

-- ====================================================================================================

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.JobTitle,
	d.Name AS [Department],
	m.FirstName + ' ' + m.LastName AS [Manager],
	e.HireDate,
	e.Salary,
	a.AddressText AS [Address]
FROM	Employees e,
		Employees m,
		Departments d,
		Addresses a
WHERE e.JobTitle = 'Sales Representative'
AND e.DepartmentID = d.DepartmentID
AND e.ManagerID = m.EmployeeID
AND e.AddressID = a.AddressID

-- ====================================================================================================

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName]
FROM Employees e
WHERE e.FirstName LIKE 'SA%'

-- ====================================================================================================

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName]
FROM Employees e
WHERE e.LastName LIKE '%ei%'

-- ====================================================================================================

-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.Salary
FROM Employees e
WHERE e.Salary > '2000'
AND e.Salary < '30000'
ORDER BY e.Salary DESC

-- ====================================================================================================

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.Salary
FROM Employees e
WHERE e.Salary = '25000'
OR e.Salary = '14000'
OR e.Salary = '12500'
OR e.Salary = '23600'
ORDER BY e.Salary DESC

-- ====================================================================================================

-- 15. Write a SQL query to find all employees that do not have manager.

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName]
FROM Employees e
WHERE e.ManagerID IS NULL

-- ====================================================================================================

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.Salary
FROM Employees e
WHERE e.Salary > '50000'
ORDER BY e.Salary DESC

-- ====================================================================================================

-- 17. Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.Salary
FROM Employees e
ORDER BY e.Salary DESC

-- ====================================================================================================

-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

SELECT
	e.FirstName,
	e.LastName,
	a.AddressText
FROM Employees e
INNER JOIN Addresses a
	ON e.AddressID = a.AddressID

-- ====================================================================================================

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

SELECT
	e.FirstName,
	e.LastName,
	a.AddressText
FROM	Employees e,
		Addresses a
WHERE e.AddressID = a.AddressID

-- ====================================================================================================

-- 20. Write a SQL query to find all employees along with their manager.

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	e.ManagerID,
	m.FirstName + ' ' + m.LastName AS [ManagerFullName]
FROM	Employees e,
		Employees m
WHERE e.ManagerID = m.EmployeeID
ORDER BY ManagerFullName

-- ====================================================================================================

-- 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT
	e.FirstName + ' ' + e.LastName AS [EmployeeFullName],
	a.AddressText AS [Address],
	m.FirstName + ' ' + m.LastName AS [ManagerFullName]
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
ORDER BY EmployeeFullName

-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================