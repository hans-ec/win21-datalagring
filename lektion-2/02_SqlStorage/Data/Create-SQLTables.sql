DROP TABLE OrderRows
DROP TABLE Orders
DROP TABLE Products
DROP TABLE Customers

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null, 
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique,
	Password varchar(max) not null
)

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(150) not null,
	Description nvarchar(max) null,
	StockPrice money not null
)
GO

CREATE TABLE Orders (
	Id int not null identity primary key,
	CustomerId int not null references Customers(Id),
	OrderDate datetime2 not null,
	DueDate datetime2 not null,
	VAT money not null,
	TotalPrice money not null
)
GO

CREATE TABLE OrderRows (
	OrderId int not null references Orders(Id),
	ProductId int not null references Products(Id),
	Quantity int not null,
	Price money not null
)