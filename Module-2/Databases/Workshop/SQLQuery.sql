-- ===================================================================

-- 1. Create table Cities with (CityId, Name)

CREATE TABLE dbo.Cities (
	CityId INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(15)
)
GO

-- ===================================================================

-- 2. Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected)

INSERT INTO Cities
		SELECT
			e.City
		FROM Employees e
		WHERE e.City IS NOT NULL
		UNION
		SELECT
			c.City
		FROM Customers c
		WHERE c.City IS NOT NULL
		UNION
		SELECT
			s.City
		FROM Suppliers s
		WHERE s.City IS NOT NULL

-- ===================================================================

-- 3. Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities

ALTER TABLE Employees
ADD CityId INT
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Cities
FOREIGN KEY (CityId)
REFERENCES Cities (CityId)
GO

ALTER TABLE Suppliers
ADD CityId INT
GO

ALTER TABLE Suppliers
ADD CONSTRAINT FK_Suppliers_Cities
FOREIGN KEY (CityId)
REFERENCES Cities (CityId)
GO

ALTER TABLE Customers
ADD CityId INT
GO

ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Cities
FOREIGN KEY (CityId)
REFERENCES Cities (CityId)
GO

-- ===================================================================

-- 4 and 6. Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
--Employees (RESULT: 9 row(s) affected)
--Suppliers (RESULT: 29 row(s) affected)
--Customers (RESULT: 91 row(s) affected)
--Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D (always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected)




-- ===================================================================

-- 5. Make the column Name in Cities Unique

ALTER TABLE Cities
ADD UNIQUE (Name)

-- ===================================================================

-- 7. Add CityId column in Orders with Foreign Key to CityId in Cities

ALTER TABLE Orders
ADD CityId INT
GO

ALTER TABLE Customers
ADD CONSTRAINT FK_Orders_Cities
FOREIGN KEY (CityId)
REFERENCES Cities (CityId)
GO

-- ===================================================================

-- 8. Now rename that column to be ShipCityId to be consistent (use stored procedure :) )

EXEC sp_rename	'Orders.CityId',
				'ShipCityId',
				'COLUMN'

-- ===================================================================

-- 9. Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)


-- ===================================================================

-- 10. Drop column ShipCity from Orders

ALTER TABLE Orders
DROP COLUMN ShipCity
GO

-- ===================================================================

-- ===================================================================

-- ===================================================================