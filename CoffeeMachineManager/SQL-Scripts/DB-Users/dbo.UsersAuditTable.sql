USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[UsersAudit] -- Only for testing.

CREATE TABLE [dbo].[UsersAudit]
(
	[AuditID] INT IDENTITY PRIMARY KEY,
	[Id] INT NOT NULL,
	[Email] NVARCHAR(320) NOT NULL,
	[Password] NCHAR(64) NOT NULL,
	[Role] NVARCHAR(20) NOT NULL,
	[UpdatedBy] NVARCHAR(128) NOT NULL,
	[UpdatedOn] DATETIME NOT NULL,
	[ActionType] NVARCHAR(6) NULL
)