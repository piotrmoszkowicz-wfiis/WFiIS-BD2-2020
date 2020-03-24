USE AdventureWorks2008
GO

CREATE FUNCTION dbo.udf_Zadanie2
(@P int, @N int)
RETURNS @Result TABLE (
    LastName varchar(max),
    FirstName varchar(max),
    EmailAddress varchar(max),
    City varchar(max)
)
AS
BEGIN
    WITH Results
    AS
    (
        SELECT TOP (SELECT COUNT(*) FROM Person.EmailAddress) LastName, FirstName, EmailAddress, City
        FROM Person.EmailAddress EA
        JOIN Person.BusinessEntity BE ON EA.BusinessEntityID = BE.BusinessEntityID
        JOIN Person.BusinessEntityAddress BEA ON BEA.BusinessEntityID = BE.BusinessEntityID
        JOIN Person.Address A ON BEA.AddressID = A.AddressID
        JOIN Person.Person P ON P.BusinessEntityID = BE.BusinessEntityID
        ORDER BY City, LastName ASC
    ),
    ResultsRowed
    AS
    (
        SELECT Results.*, NTILE(@N) OVER (ORDER BY Results.City, Results.LastName ASC) AS Quantile FROM Results
    )
    INSERT INTO @Result SELECT ResultsRowed.LastName, ResultsRowed.FirstName, ResultsRowed.EmailAddress, ResultsRowed.City FROM ResultsRowed WHERE ResultsRowed.Quantile = @P;
    RETURN;
END
GO

USE AdventureWorks2008
GO
SELECT * FROM [dbo].[udf_Zadanie2](2, 10)
GO;