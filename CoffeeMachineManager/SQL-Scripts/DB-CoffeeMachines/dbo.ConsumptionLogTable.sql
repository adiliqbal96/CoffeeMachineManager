USE CoffeeMachineManager;

CREATE TABLE [dbo].[ConsumptionLogs]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CoffeeMachineId] INT FOREIGN KEY
        REFERENCES CoffeeMachines(Id)
        ON DELETE CASCADE NOT NULL,
    [CoffeeUsed] INT NOT NULL,
    [Timestamp] DATETIME NOT NULL DEFAULT GETUTCDATE()
);