CREATE TABLE motherboard_lanconnector (
	MotherboardId integer NOT NULL PRIMARY KEY REFERENCES part(Id) ON DELETE CASCADE,
	Count integer NOT NULL CHECK (Count > 0 AND Count < 20)
);