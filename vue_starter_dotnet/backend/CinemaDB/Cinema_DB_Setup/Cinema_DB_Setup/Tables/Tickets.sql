CREATE TABLE [dbo].[Tickets]
(
	[TicketId] INT NOT NULL PRIMARY KEY, 
    [ShowingsId] INT NOT NULL, 
    [SeatId] INT NOT NULL, 
    [PurchasesId] INT NOT NULL, 
    [Price] MONEY NOT NULL
)
