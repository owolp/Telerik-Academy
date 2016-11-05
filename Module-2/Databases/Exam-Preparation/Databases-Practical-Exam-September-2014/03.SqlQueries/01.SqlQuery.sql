-- 1.	Get all toys’s name and price having type of “puzzle” and price above $10.00 ordering them by price

USE ToyStore

SELECT
	t.Name,
	t.Price
FROM Toys t
WHERE t.Type = 'puzzle' AND t.Price > '10'
ORDER BY t.Price

GO