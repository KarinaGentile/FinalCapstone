CREATE TABLE [dbo].[Users]
(
	[UsersId] INT NOT NULL PRIMARY KEY, 
    [email] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(MAX) NOT NULL
)
