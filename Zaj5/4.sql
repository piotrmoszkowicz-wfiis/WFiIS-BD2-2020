CREATE FUNCTION dbo.udf_Zadanie4
(@Limit int)
RETURNS @Result TABLE (
    BusinessEntityID INT,
    PersonType VARCHAR(2),
    NameStyle NameStyle,
    Title VARCHAR(8),
    FirstName VARCHAR(50),
    MiddleName VARCHAR(50),
    LastName VARCHAR(50),
    Suffix VARCHAR(10),
    EmailPromotion INT,
    AdditionalContactInfo XML(Person.AdditionalContactInfoSchemaCollection),
    Demographics XML(Person.IndividualSurveySchemaCollection),
    rowguid UNIQUEIDENTIFIER,
    ModifiedDate DATETIME,
    OrderNumber INT
)
BEGIN
	WITH Results
	AS
	(
		SELECT SalesPersonID, COUNT(*) OrdersNumber FROM Person.EmailAddress EA
		JOIN Person.BusinessEntity BE ON EA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.BusinessEntityAddress BEA ON BEA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.Address A ON BEA.AddressID = A.AddressID
		JOIN Person.Person P ON P.BusinessEntityID = BE.BusinessEntityID
		JOIN HumanResources.Employee Emp ON P.BusinessEntityID = Emp.BusinessEntityID
		JOIN Sales.SalesPerson SP ON SP.BusinessEntityID = Emp.BusinessEntityID
		JOIN Sales.SalesOrderHeader SOH ON SOH.SalesPersonID = SP.BusinessEntityID
		GROUP BY SalesPersonID
	),
	ResultsPersoned
	AS
	(
		SELECT TOP (@Limit) P.*, Results.OrdersNumber FROM Results
		JOIN Person.Person P ON P.BusinessEntityID = Results.SalesPersonID
		ORDER BY OrdersNumber DESC
	)
	INSERT INTO @Result SELECT * FROM ResultsPersoned
	RETURN;
END
GO

SELECT * FROM dbo.udf_Zadanie4(4)
GO