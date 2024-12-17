USE CoffeeMachineManager;
GO

-- Code mainly used from: https://www.mssqltips.com/sqlservertip/4055/create-a-simple-sql-server-trigger-to-build-an-audit-trail/

DROP TRIGGER IF EXISTS TR_Users_Audit -- Only for testing.
GO

CREATE TRIGGER TR_Users_Audit ON dbo.Users
FOR UPDATE, INSERT, DELETE
AS
IF (ROWCOUNT_BIG() = 0)
RETURN;
BEGIN
	DECLARE @Operation VARCHAR(6) = 
    CASE WHEN EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted) 
        THEN 'Update'
    WHEN EXISTS(SELECT * FROM inserted) 
        THEN 'Insert'
    -- Currently doesn't work for delete, not sure why.
    --WHEN EXISTS(SELECT * FROM deleted)
    --    THEN 'Delete'
    ELSE 
        NULL -- Unknown operation.
    END;
	INSERT INTO UsersAudit
	(Id, Email, Password, Role, UpdatedBy, UpdatedOn, ActionType)
	SELECT i.Id, i.Email, i.Password, i.Role, SUSER_SNAME(), GETUTCDATE(), @Operation
	FROM dbo.Users t
	inner join inserted i on t.Id = i.Id
END;