CREATE TABLE account (
	Id integer PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	Name varchar(30) NOT NULL,
	Password varchar(256) NOT NULL,
	Unique(Id)
);
