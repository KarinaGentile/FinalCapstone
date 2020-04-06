
USE master
GO


-- Delete the db if it already exists
DROP DATABASE IF Exists SmallTownCinema

-- Create a new database
CREATE Database SmallTownCinema;
GO
-- Change to the new DB
USE SmallTownCinema
GO

begin tran

CREATE TABLE [dbo].[Theaters]
(
	[TheaterId] INT NOT NULL identity PRIMARY KEY,
	[TheaterName] NVARCHAR(50) NULL
)



CREATE TABLE [dbo].[Movies]
(
	[MovieId] INT NOT NULL identity PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [PosterURL] NVARCHAR(MAX) NULL
)

CREATE TABLE [dbo].[Showings]
(
	[ShowingsId] INT NOT NULL identity PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [DateTime] DATETIME NOT NULL, 
    [TheaterId] INT NOT NULL

	constraint fk_showing_theater foreign key (TheaterId) references theaters (TheaterId),
	constraint fk_showing_movie foreign key (MovieId) references Movies (MovieId)
)

insert into Movies
(Title)
values
('A Movie')
,('Bee Movie')
,('Catch Me If You Can')

insert into Theaters
(TheaterName)
values
('1')
,('2')
,('3')
,('4')
,('5')
,('6')
,('7')

insert into Showings
(MovieId, DateTime, TheaterId)
values
(1, GETDATE(), 1)
,(2, GETDATE(), 2)
,(3, GETDATE(), 3)
,(1, GETDATE(), 4)
,(2, GETDATE(), 5)
,(3, GETDATE(), 6)
,(3, GETDATE(), 7)

commit tran

