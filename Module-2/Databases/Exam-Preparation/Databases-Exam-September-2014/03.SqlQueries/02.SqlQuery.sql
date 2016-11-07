USE Company

SELECT
	d.Name,
	COUNT(*) AS [NumberOfEmployees]
FROM Departments d
INNER JOIN Employees e
	ON d.Id = e.DepartmentId
	GROUP BY d.Name
	ORDER BY NumberOfEmployees

GO