USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[Users] -- Only for testing.

CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Email] NVARCHAR(320) NOT NULL,
	[Password] NCHAR(64) NOT NULL
		CONSTRAINT CHK_Password_Hash
		CHECK ([Password] like '[0-9a-f]{0,128}' AND LEN([Password]) = 64),
	[Role] NVARCHAR(20) NOT NULL
	-- AND LEN([Password]) = 64)
)