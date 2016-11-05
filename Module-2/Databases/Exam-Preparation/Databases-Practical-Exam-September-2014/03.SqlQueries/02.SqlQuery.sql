-- 3.	2.	Get all manufacturers’ name and how many toys they have in the age range of 5 to 10 years, inclusive

USE ToyStore

SELECT
	m.Name,
	COUNT(*) AS [ToysCount]
FROM Manufacturers m
INNER JOIN Toys t
	ON m.Id = t.ManufacturerId
INNER JOIN AgeRanges ar
	ON t.AgeRangeId = ar.Id
WHERE ar.MinAge >= 5 AND ar.MaxAge <= 10
GROUP BY m.Name
ORDER BY m.Name

GO

-- OR

SELECT
	Manufacturers.Name,
	(SELECT
			COUNT(*)
		FROM Toys
		INNER JOIN AgeRanges
			ON Toys.AgeRangeId = AgeRanges.Id
		WHERE AgeRanges.MinAge >= 5
		AND AgeRanges.MaxAge <= 10
		AND Manufacturers.Id = Toys.ManufacturerId)
FROM Manufacturers
ORDER BY Name