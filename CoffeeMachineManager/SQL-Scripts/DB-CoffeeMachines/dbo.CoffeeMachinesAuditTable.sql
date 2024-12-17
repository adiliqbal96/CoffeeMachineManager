USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[CoffeeMachinesAudit] -- Only for testing.

CREATE TABLE [dbo].[CoffeeMachinesAudit]
(
    [AuditId] INT IDENTITY PRIMARY KEY,         -- Primary key with identity increment
    [Id] INT NOT NULL,
    [Location] NVARCHAR(255) NOT NULL,          -- Location of the coffee machine
    [Type] NVARCHAR(100) NULL,                  -- Type of coffee machine
    [Status] NVARCHAR(50) DEFAULT 'Active',     -- Status of the coffee machine, default to 'Active'
    [UpdatedBy] NVARCHAR(128) NOT NULL,
	[UpdatedOn] DATETIME NOT NULL,
	[ActionType] NVARCHAR(6) NULL
);
