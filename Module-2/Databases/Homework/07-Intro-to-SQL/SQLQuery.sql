-- ====================================================================================================

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT
	d.Name AS DepartmentName,
	e.FirstName + ' ' + e.LastName AS ManagerName
FROM Departments d
INNER JOIN Employees e
	ON d.ManagerID = e.EmployeeID

-- OR

SELECT
	d.Name AS DepartmentName,
	e.FirstName + ' ' + e.LastName AS ManagerName
FROM	Departments d,
		Employees e
WHERE d.ManagerID = e.EmployeeID

-- ====================================================================================================

-- 5. Write a SQL query to find all department names.

SELECT
	d.Name AS DepartmentName
FROM Departments d

-- ====================================================================================================

-- 6. Write a SQL query to find the salary of each employee.

SELECT
	e.FirstName + ' ' + e.LastName AS Employee,
	e.Salary
FROM Employees e

-- ====================================================================================================

-- 7. Write a SQL to find the full name of each employee.
SELECT
	e.FirstName + ' ' + e.LastName AS EmployeeFullName
FROM Employees e

-- ====================================================================================================

-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
-- The produced column should be named "Full Email Addresses".

SELECT
	e.FirstName + '.' + e.LastName + '@telerik.com' AS 'Full Email Addresses'
FROM Employees e

-- ====================================================================================================

-- 9. Write a SQL query to find all different employee salaries.

SELECT DISTINCT
	e.Salary
FROM Employees e

-- ====================================================================================================

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT
	e1.FirstName + ' ' + e1.LastName AS EmployeeFullName,
	e1.JobTitle,
	d.Name AS 'Department',
	e2.FirstName + ' ' + e2.LastName AS 'Manager',
	e1.HireDate,
	e1.Salary,
	a.AddressText AS 'Address'
FROM	Employees e1, Employees e2,
		Departments d,
		Addresses a
WHERE e1.JobTitle = 'Sales Representative'
AND e1.DepartmentID = d.DepartmentID
AND e1.ManagerID = e2.EmployeeID
AND e1.AddressID = a.AddressID

-- ====================================================================================================

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT
	e.FirstName + ' ' + e.LastName AS EmployeeFullName
FROM Employees e
WHERE e.FirstName LIKE 'SA%'

-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================
-- ====================================================================================================