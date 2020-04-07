CREATE TABLE [dbo].[Showings]
(
	[ShowingsId] INT NOT NULL PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [DateTime] DATETIME NOT NULL, 
    [TheaterId] INT NOT NULL, 
    CONSTRAINT [FK_Showings_Movie] FOREIGN KEY ([MovieId]) REFERENCES Movie([MovieId])
)
