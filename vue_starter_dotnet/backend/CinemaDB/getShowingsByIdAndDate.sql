--select * from showings
declare @id int = 1
declare @currentTime datetime = getdate()
declare @selectedDate datetime = convert(date, getdate())


select * from Showings where MovieId = @id and starttime > @currentTime and ( convert(date,starttime) = @selectedDate )