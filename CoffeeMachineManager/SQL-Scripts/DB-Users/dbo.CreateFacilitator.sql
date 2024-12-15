USE master;

-- Creating a new login for user,
-- creating a new role with execute and insert rights,
-- then finally assigning that role to the user.

CREATE LOGIN john WITH PASSWORD = 'tempPWD456';

USE CoffeeMachineManager;

CREATE ROLE dbfacilitator;

GRANT SELECT ON CoffeeMachines TO dbfacilitator;
GRANT INSERT ON CoffeeMachines TO dbfacilitator;
GRANT DELETE ON CoffeeMachines TO dbfacilitator;

GRANT SELECT ON ConsumptionLogs TO dbfacilitator;
GRANT INSERT ON ConsumptionLogs TO dbfacilitator;
GRANT UPDATE ON ConsumptionLogs TO dbfacilitator;

CREATE USER john FOR LOGIN john;
ALTER ROLE dbfacilitator ADD MEMBER john;