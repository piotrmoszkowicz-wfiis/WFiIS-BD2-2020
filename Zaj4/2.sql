USE AdventureWorks2008
GO

WITH Products_CTE (SOid, PRid, qty, total, ProductName)
AS
(
	SELECT SalesOrderID As SOid, Det.ProductID As PRid, OrderQty As qty, LineTotal As total, Prod.Name As ProductName
	FROM Sales.SalesOrderDetail Det
	JOIN Production.Product Prod ON Det.ProductID = Prod.ProductID
),
Clients_CTE (SalesOrderID, LastName, AddressLine1)
AS
(
	SELECT SalesOrderID, p.LastName, a.AddressLine1 FROM Sales.SalesOrderHeader soh
	JOIN Sales.Customer c ON c.CustomerID = soh.CustomerID
	JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
	JOIN Person.BusinessEntityAddress bea ON bea.BusinessEntityID = p.BusinessEntityID
	JOIN Person.Address a ON a.AddressID = bea.AddressID
)
SELECT Clients_CTE.*, Products_CTE.* FROM Clients_CTE JOIN Products_CTE ON Clients_CTE.SalesOrderID = Products_CTE.SOid
WHERE Products_CTE.ProductName LIKE '%[^-A-Za-z0-9/.+$]%';