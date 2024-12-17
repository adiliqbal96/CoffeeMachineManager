USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[CoffeeMachines] -- Only for testing.

CREATE TABLE [dbo].[CoffeeMachines]
(
    [Id] INT IDENTITY PRIMARY KEY,              -- Primary key with identity increment
    [Location] NVARCHAR(255) NOT NULL,          -- Location of the coffee machine
    [Type] NVARCHAR(100) NULL,                  -- Type of coffee machine
    [Status] NVARCHAR(50) DEFAULT 'Active'      -- Status of the coffee machine, default to 'Active'
);
