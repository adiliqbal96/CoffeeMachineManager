USE master;

-- Creating a new login for user,
-- creating a new role with execute and insert rights,
-- then finally assigning that role to the user.

CREATE LOGIN camilla WITH PASSWORD = 'tempPWD123';

USE CoffeeMachineManager;

CREATE ROLE dbadmin;

GRANT EXECUTE TO dbadmin;
GRANT SELECT ON Users TO dbadmin;
GRANT INSERT ON Users TO dbadmin;
GRANT DELETE ON Users TO dbadmin;

GRANT SELECT ON UsersAudit TO dbadmin;

GRANT SELECT ON CoffeeMachinesAudit TO dbadmin;
GRANT SELECT ON ConsumptionLogsAudit TO dbadmin;

CREATE USER camilla FOR LOGIN camilla;
ALTER ROLE dbadmin ADD MEMBER camilla;