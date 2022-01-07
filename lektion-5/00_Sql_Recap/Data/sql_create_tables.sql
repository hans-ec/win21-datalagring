DROP TABLE Products
DROP TABLE SubCategories
DROP TABLE Categories

CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(200) not null unique
)
GO

CREATE TABLE SubCategories (
	Id int not null identity primary key,
	Name nvarchar(200) not null unique,
	CategoryId int not null references Categories(Id)
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(200) not null,
	Description nvarchar(max) null,
	Price money not null,
	SubCategoryId int not null references SubCategories(Id)
)