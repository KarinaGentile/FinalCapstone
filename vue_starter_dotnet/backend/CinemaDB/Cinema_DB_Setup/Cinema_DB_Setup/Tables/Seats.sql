CREATE TABLE [dbo].[Seats]
(
	[SeatId] INT NOT NULL PRIMARY KEY, 
    [TheaterId] INT NOT NULL, 
    [SeatNumber] NCHAR(2) NOT NULL
)
