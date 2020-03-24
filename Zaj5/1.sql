USE AdventureWorks2008
GO

CREATE FUNCTION dbo.udf_Zadanie1
(@BusinessEntityID int, @Delimiter char(1))
RETURNS varchar(max)
AS
BEGIN
    DECLARE @ConcatedString varchar(max)
    SET @ConcatedString = (
		SELECT '"' + FirstName + '"' + @Delimiter  + '"' + LastName + '"'  + @Delimiter  + '"' + EmailAddress + '"'  + @Delimiter  + '"' + City + '"'  AS ConcatedString 
		FROM Person.EmailAddress EA
		JOIN Person.BusinessEntity BE ON EA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.BusinessEntityAddress BEA ON BEA.BusinessEntityID = BE.BusinessEntityID
		JOIN Person.Address A ON BEA.AddressID = A.AddressID
		JOIN Person.Person P ON P.BusinessEntityID = BE.BusinessEntityID
		WHERE EA.BusinessEntityID = @BusinessEntityID
    )
    RETURN @ConcatedString
END
GO

SELECT dbo.udf_Zadanie1(2, ': ');