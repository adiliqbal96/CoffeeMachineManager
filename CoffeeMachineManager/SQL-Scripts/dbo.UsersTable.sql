CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY PRIMARY KEY,
	-- Will have look into adjusting sizes.
	[Email] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Role] NVARCHAR(50) NOT NULL
)
