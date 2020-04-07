CREATE TABLE [dbo].[tab]
(
	[MovieId] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Posters] NVARCHAR(MAX) NULL, 
    [Genre] NVARCHAR(25) NOT NULL, 
    CONSTRAINT [FK_Movie] FOREIGN KEY ([Column]) REFERENCES [ToTable]([ToTableColumn])
)
