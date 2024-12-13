USE master;

-- Creating a new login for user,
-- creating a new role with execute and insert rights,
-- then finally assigning that role to the user.

CREATE LOGIN camilla WITH PASSWORD = 'tempPWD123';

USE CoffeeMachineManager;

CREATE ROLE dbadmin;
GRANT SELECT ON Users TO dbadmin;
GRANT EXECUTE ON Users TO dbadmin;
GRANT INSERT ON Users TO dbadmin;
CREATE USER camilla FOR LOGIN camilla;
ALTER ROLE dbadmin ADD MEMBER camilla;