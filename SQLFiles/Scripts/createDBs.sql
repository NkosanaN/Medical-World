--create DB
create database Users
--create Table
create table User_1
(
	UserId int primary key identity(1,1),
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Email varchar(100) not null,
	Password varchar(100) not null,
	DateOfBirth DATETIME,
	TimeCreated DATETIME
)
--Userr DB
use Users
--test to see if DB is Created
select * from User_1


create table Doctors
(
	id int primary key identity(1,1),
	DateChange DATETIME,
	Name varchar(20),
	Age int ,
	Surname varchar(20)
)

