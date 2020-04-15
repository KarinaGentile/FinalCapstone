begin tran


insert into users
(email, password)
values
('a@b.com', 'password')

insert into Purchases
(UserId, DateTime, Total_Price)
values
(1,GETDATE(),10)

insert into tickets
(ShowingId, SeatName, PurchaseId, price) --this showing is Apr 15 at 10AM
values
(1, 'A1', 1, 10),
(1, 'A2', 1, 10),
(1, 'A3', 1, 10),
(1, 'A4', 1, 10)

insert into Purchases
(UserId,DateTime,Total_Price)
values
(1,GETDATE(),10)
select @@identity

declare @newPurchId int = (select max(purchaseId) from Purchases)
declare @showId int = 15

insert into tickets
(ShowingId, SeatName, PurchaseId, Price)
values(@showId, 'B1', @newPurchId,5)
,(@showId, 'B2', @newPurchId,5)
,(@showId, 'B3', @newPurchId,5)
,(@showId, 'F11', @newPurchId,5)
,(@showId, 'F12', @newPurchId,5)
,(@showId, 'C14', @newPurchId,5)
,(@showId, 'C15', @newPurchId,5)


commit tran