CREATE TABLE [dbo].[Purchases]
(
	[PurchasesId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [DateTime] DATETIME NOT NULL, 
    [Total_Price] MONEY NOT NULL
)
