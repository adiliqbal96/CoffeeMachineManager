UPDATE Users
SET Password = HASHBYTES('SHA2_256', 'newpassword')
WHERE Email = 'admin@coffeemanager.com';

UPDATE Users
SET Password = HASHBYTES('SHA2_256', 'newpassword')
WHERE Email = 'employee@coffeemanager.com';
