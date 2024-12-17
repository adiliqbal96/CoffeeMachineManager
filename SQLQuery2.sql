DELETE FROM dbo.Users WHERE Id = 2 OR Id = 3;

INSERT INTO dbo.Users (Email, Password, Role)
VALUES
('admin@coffeemanager.com', 'AdminPassword123', 'Admin'),
('employee@coffeemanager.com', 'EmployeePassword123', 'Employee');
