CREATE TABLE pcieconnector (
	Id integer PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	Length pcielength NOT NULL UNIQUE,
	Version pcieversion NOT NULL UNIQUE
);