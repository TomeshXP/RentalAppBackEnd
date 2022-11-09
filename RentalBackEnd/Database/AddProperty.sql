create table AddProperty(
PropertyId int primary key identity,
PropertyName varchar(100),
SqureFeet varchar(50),
RentalCost decimal,
City varchar(50),
Location varchar(max),
Type varchar(20),
LandLordName varchar(50),
PropertyImage varchar(max),
RentarId int FOREIGN KEY REFERENCES LandLord(RentarId)
)


drop table AddProperty




alter procedure _spAddProperty
(
@PropertyName varchar(100),
@SqureFeet varchar(50),
@RentalCost decimal,
@City varchar(50),
@Location varchar(max),
@Type varchar(20),
@LandLordname varchar(50),
@PropertyImage varchar(max),
@RentarId int
)
as 
begin
insert into AddProperty(PropertyName,SqureFeet,RentalCost,City,Location,Type,LandLordName,PropertyImage,RentarId) values(@PropertyName,@SqureFeet,@RentalCost,@City,@Location,@Type,@LandLordname,@PropertyImage,@RentarId)
end

select * from AddProperty

delete from AddProperty where PropertyId=2

----------------------------


alter procedure _spPropertyResponse(@RentarId int)
as
begin
select * from AddProperty where Not RentarId=@RentarId
end



-----------
---Get My Properties

create procedure _spgetMyProperties(@RentarId int)
as
begin
select * from AddProperty where RentarId=@RentarId
end



-----DeleteProperty------
alter procedure _spDeletePropery(@PropertyId int)
as 
begin
delete from AddProperty where PropertyId=@PropertyId
end


--------GetProperyById------
alter procedure _spGetPropertyById(@PropertyId int)
as
begin
select * from AddProperty where PropertyId=@PropertyId
end


------UpdateProperty-------
create procedure _spUpdateProperty(
@PropertyName varchar(100),
@SqureFeet varchar(50),
@RentalCost decimal,
@City varchar(50),
@Location varchar(max),
@Type varchar(20),
@LandLordName varchar(50),
@PropertyImage varchar(max),
@PropertyId Int 
)
as
begin
update AddProperty set Propertyname=@PropertyName,PropertyImage=@PropertyImage,SqureFeet=@SqureFeet,RentalCost=@RentalCost,City=@City,Location=@Location,Type=@Type,LandLordName=@LandLordName where PropertyId=@PropertyId
end




------Send Request Table-------

create table BuyerTable(
OrderId int primary key Identity,
BuyerId int Foreign key references LandLord(RentarId),
SellerId int Foreign key references LandLord(RentarId),
PropertyId int Foreign key references AddProperty(PropertyId),
LandLordName varchar(50),
RentAmount decimal,
SecurityDeposit decimal,
)




drop table BuyerTable

drop procedure _spBuyerTable


-----------Send Requesst Procedure ---------
create procedure _spBuyerTable(
@BuyerId int,
@SellerId int,
@PropertyId int,
@LandLordName varchar(50),
@RentAmount decimal,
@SecurityDeposit decimal
)
as
begin
insert into BuyerTable (BuyerId,SellerId,PropertyId,LandLordName,RentAmount,SecurityDeposit) values(@BuyerId,@SellerId,@PropertyId,@LandLordName,@RentAmount,@SecurityDeposit)
end


select * from BuyerTable

delete from BuyerTable where OrderId=1




------Get BuyerTable -------
drop procedure _spGetShowRequest

create procedure _spGetShowRequest
AS
begin
select l.UserName,l.Address,l.Image,l.Email,l.Number,
b.RentAmount,b.SecurityDeposit,
a.PropertyImage,a.City,a.Location,a.SqureFeet,a.Type
From LandLord l
 Join AddProperty a ON l.RentarId=13 
 join BuyerTable b ON b.PropertyId=a.PropertyId where PropertyId=3
end



--((LandLord INNER JOIN BuyerTable  ON  8=13)
--INNER JOIN AddProperty ON 25=25)

select * from AddProperty

select * from LandLord

select * from BuyerTable


alter procedure _spGetShowRequest(
@PropertyId int
)
as
begin
select bt.RentAmount,bt.SecurityDeposit,
l.Username,l.Email,l.Number,l.Address,l.Image
from BuyerTable bt 
inner join LandLord l on l.RentarId = bt.BuyerId
where bt.PropertyId = @PropertyId
end


