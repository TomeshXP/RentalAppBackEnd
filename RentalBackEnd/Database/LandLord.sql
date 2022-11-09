create database RentalHouse

use RentalHouse

drop table Renter

create table LandLord(
RentarId int primary key Identity,
Username varchar(100) Not Null,
Password varchar(50) Not Null,
Email varchar(100) Not Null,
Number varchar(20) Not Null,
Address varchar(max) Not Null,
Image varchar(max) 
)
-- _spLandlordRegistration 'Tomeshwar','Test@123','test@gmail.com','7878787878','Gurugram','image.jpg'
alter procedure _spLandlordRegistration(
@UserName varchar(100),
@Password varchar(50),
@Email varchar(100),
@Number varchar(20),
@Address varchar(max),
@Image varchar(max)
)
as
begin
insert into LandLord (Username,Password,Email,Number,Address,Image) values(@UserName,@Password,@Email,@Number,@Address,@Image)
end

delete from LandLord where  RentarId in(11,12)

select * from LandLord

update LandLord set Username='Tomesh' where RentarId=1

DROP PROCEDURE _spRenterRegistration

TRUNCATE TABLE LandLord;
--------------------------

alter procedure _spLandLordLogin(
@Email varchar(100),
@Password varchar(50)
)
as
begin
select RentarId,Email,Password,UserName from LandLord where Email =@Email and Password=@Password
end

exec _spLandLordLogin 'test@gmail.com','Test@123'


