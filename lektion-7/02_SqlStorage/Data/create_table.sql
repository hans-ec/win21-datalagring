DROP TABLE Users

CREATE TABLE Users (
	Id uniqueidentifier not null primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null
)