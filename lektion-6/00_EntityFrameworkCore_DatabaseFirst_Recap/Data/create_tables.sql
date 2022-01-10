DROP TABLE Customers
DROP TABLE Addresses

CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(50) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null,
	Country nvarchar(50) not null
)
GO

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)