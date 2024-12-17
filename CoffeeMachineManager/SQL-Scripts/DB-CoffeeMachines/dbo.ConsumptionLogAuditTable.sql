USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[ConsumptionLogsAudit] -- Only for testing.

CREATE TABLE [dbo].[ConsumptionLogsAudit]
(
    [AuditId] INT IDENTITY PRIMARY KEY,
    [CoffeeMachineId] INT NOT NULL,
    [CoffeeUsed] INT NOT NULL,
    [CreatedOn] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedBy] NVARCHAR(128) NOT NULL,
	[UpdatedOn] DATETIME NOT NULL,
	[ActionType] NVARCHAR(6) NULL
);