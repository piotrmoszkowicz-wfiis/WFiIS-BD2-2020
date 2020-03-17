USE AdventureWorks
GO

WITH Employees (Employee, ManagerID, EmployeeID)
AS
(
	SELECT LastName + ' ' + FirstName as Employee, ManagerID, EmployeeID
	FROM HumanResources.Employee
	JOIN Person.Contact ON HumanResources.Employee.ContactID= Person.Contact.ContactID
)
SELECT Employees.Employee, Managers.Employee AS [Manager] FROM Employees JOIN Employees Managers ON Managers.EmployeeID = Employees.ManagerID;