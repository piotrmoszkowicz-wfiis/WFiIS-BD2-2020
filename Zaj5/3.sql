USE AdventureWorks2008
GO

CREATE FUNCTION dbo.udf_Zadanie3
(@LastName varchar(max))
RETURNS @Result TABLE (
    LastName varchar(max),
    OrderDate DATE,
    TotalDue MONEY
)
BEGIN
	INSERT INTO @Result
		SELECT LastName, OrderDate, TotalDue FROM Person.EmailAddress EA
		JOIN Person.BusinessEntity BE ON EA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.BusinessEntityAddress BEA ON BEA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.Address A ON BEA.AddressID = A.AddressID
		JOIN Person.Person P ON P.BusinessEntityID = BE.BusinessEntityID
		JOIN HumanResources.Employee Emp ON P.BusinessEntityID = Emp.BusinessEntityID
		JOIN Sales.SalesPerson SP ON SP.BusinessEntityID = Emp.BusinessEntityID
		JOIN Sales.SalesOrderHeader SOH ON SOH.SalesPersonID = SP.BusinessEntityID
		WHERE LastName = @LastName
	RETURN;
END
GO

USE AdventureWorks2008
GO
SELECT * FROM [dbo].[udf_Zadanie3]('Jiang')
GO;
