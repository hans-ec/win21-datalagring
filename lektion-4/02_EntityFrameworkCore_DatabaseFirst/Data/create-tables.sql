DROP TABLE Users
DROP TABLE Addresses
DROP TABLE Products

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(200) not null,
	Description nvarchar(max) null,
	Price money not null default 0
)

CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(50) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null
)
GO

CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)