USE CoffeeMachineManager;

CREATE TABLE [dbo].[ConsumptionLogsAudit]
(
    [AuditId] INT IDENTITY PRIMARY KEY,
    [CoffeeMachineId] INT FOREIGN KEY
        REFERENCES CoffeeMachines(Id) NULL,
    [CoffeeUsed] INT NOT NULL,
    [CreatedOn] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedBy] NVARCHAR(128) NOT NULL,
	[UpdatedOn] DATETIME NOT NULL,
	[ActionType] NVARCHAR(6) NULL
);