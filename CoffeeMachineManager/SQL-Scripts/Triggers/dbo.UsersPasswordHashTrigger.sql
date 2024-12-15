USE CoffeeMachineManager;
GO

DROP TRIGGER IF EXISTS TR_Users_Password_Hash -- Only for testing.
GO

CREATE TRIGGER TR_Users_Password_Hash ON dbo.Users
FOR UPDATE, INSERT
AS
IF (ROWCOUNT_BIG() = 0)
RETURN;
SELECT Password FROM inserted AS i
IF NOT (REGEXP_LIKE(i, '[0-9a-f]{64}')) BEGIN
	RAISERROR('A member must be at least 18 years of age!', 16, 1);
	ROLLBACK TRANSACTION;
	RETURN;
END;