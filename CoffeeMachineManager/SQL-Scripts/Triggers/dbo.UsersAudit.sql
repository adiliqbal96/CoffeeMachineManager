USE CoffeeMachineManager;
GO

-- Code mainly used from: https://www.mssqltips.com/sqlservertip/4055/create-a-simple-sql-server-trigger-to-build-an-audit-trail/

CREATE TRIGGER TR_Users_Audit ON dbo.Users
AFTER UPDATE, INSERT, DELETE
AS  
IF (ROWCOUNT_BIG() = 0)
RETURN;
BEGIN
	INSERT INTO UsersAudit
	(Id, Email, Password, Role, UpdatedBy, UpdatedOn)
	SELECT i.Id, i.Email, i.Password, i.Role, SUSER_SNAME(), getdate()
	FROM dbo.Users t
	inner join inserted i on t.Id = i.Id
END;