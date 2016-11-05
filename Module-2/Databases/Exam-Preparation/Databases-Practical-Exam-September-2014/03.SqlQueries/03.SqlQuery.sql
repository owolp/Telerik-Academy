-- 3.	Get all toys’ name, price and color from category “boys” 

USE ToyStore

SELECT
	t.Name,
	t.Price,
	t.Color
FROM Toys t
INNER JOIN ToysCategories tc
	ON t.Id = tc.ToyId
INNER JOIN Categories c
	ON tc.CategoryId = c.Id
WHERE c.Name = 'boys'

GO