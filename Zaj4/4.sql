USE AdventureWorks2008
GO

WITH Sums (BusinessEntityID, Total)
AS
(
	SELECT TOP 20 p.BusinessEntityID, SUM(soh.SubTotal) as [Total]
	FROM Sales.SalesOrderHeader soh
	JOIN Sales.Customer c ON c.CustomerID = soh.CustomerID
	JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
	JOIN Person.BusinessEntityAddress bea ON bea.BusinessEntityID = p.BusinessEntityID
	JOIN Person.Address a ON a.AddressID = bea.AddressID
	GROUP BY p.BusinessEntityID
	ORDER BY Total DESC
),
SumsRowed 
AS
(
	SELECT Sums.*, NTILE(4) OVER (ORDER BY Sums.Total DESC) AS Quantile FROM Sums
)
SELECT SumsRowed.BusinessEntityID, SumsRowed.Total FROM SumsRowed WHERE SumsRowed.Quantile = 2;