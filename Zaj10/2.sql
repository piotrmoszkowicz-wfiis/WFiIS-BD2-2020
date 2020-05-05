USE AdventureWorks2008;
GO

WITH Result_CTE (FirstName, LastName, Diff)
AS
(
	SELECT
		FirstName,
		LastName,
		Demographics.value('declare default element namespace "http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey";(/IndividualSurvey/NumberChildrenAtHome)[1][. >0]','INT') - Demographics.value('declare default element namespace "http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey";(/IndividualSurvey/TotalChildren)[1][. >0]','INT') as Diff
	FROM Person.Person
)
SELECT FirstName, LastName, Diff FROM Result_CTE ORDER BY Diff DESC;