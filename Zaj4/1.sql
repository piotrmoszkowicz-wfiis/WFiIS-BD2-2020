USE AdventureWorks2008
GO
SELECT [Zmiana], [Production], [Information Services], [Marketing], [Research and Development]
FROM
(
	SELECT shft.Name AS [Zmiana], Dept.Name AS [Name], 1 AS [Quan]
	FROM HumanResources.Employee Emp JOIN
	HumanResources.EmployeeDepartmentHistory Hist ON Emp.BusinessEntityID =
	Hist.BusinessEntityID
	INNER JOIN HumanResources.Department Dept
	ON Hist.DepartmentID = Dept.DepartmentID
	INNER JOIN HumanResources.Shift Shft
	ON Hist.ShiftID = Shft.ShiftID
	WHERE Hist.EndDate IS NULL
	AND Dept.Name IN ('Production', 'Information Services', 'Marketing', 'Research and Development')
) DataTableAlias

PIVOT
(
	SUM(Quan)
	FOR Name
	IN (
		[Production], [Information Services], [Marketing], [Research and Development]
	)
) PivotTableAlias
