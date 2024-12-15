USE CoffeeMachineManager;

-- This will fail because the password is not hashed.
-- Hashing is done through the application.
INSERT INTO Users (Email, Password, Role)
VALUES ('frk003@edu.zealand.dk', '36b52b17eaaf7620cbe62322c236602046fde6fd091aa13584ae07dca2ea781e', 'Employee');