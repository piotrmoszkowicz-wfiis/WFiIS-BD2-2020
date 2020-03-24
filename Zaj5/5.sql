USE AdventureWorks2008
GO

CREATE VIEW rndView AS SELECT RAND() rndResult
GO

CREATE FUNCTION dbo.udf_Zadanie5
(@Min INT, @Max INT)
RETURNS DATE
BEGIN
	DECLARE @Random INT
	SELECT @Random = ROUND(((@Max - @Min -1) * (SELECT rndResult FROM rndView) + @Min), 0)
	RETURN DATEADD(day, -@Random, GETDATE())
END
GO

SELECT dbo.udf_Zadanie5(1, 100)
GO