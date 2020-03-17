USE Lab
GO

EXECUTE AS USER = 'User_Au';
SELECT HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'SELECT') as selectPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'INSERT') as insertPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'UPDATE') as updatePermission;
REVERT;

EXECUTE AS USER = 'User_Fe';
SELECT HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'SELECT') as selectPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'INSERT') as insertPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'UPDATE') as updatePermission;
REVERT;

EXECUTE AS USER = 'User_Pt';
SELECT HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'SELECT') as selectPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'INSERT') as insertPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'UPDATE') as updatePermission;
REVERT;

EXECUTE AS LOGIN = 'MSSQLSERVER\B';
SELECT HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'SELECT') as selectPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'INSERT') as insertPermission, HAS_PERMS_BY_NAME ('dbo.TabA', 'OBJECT', 'UPDATE') as updatePermission;
REVERT;
