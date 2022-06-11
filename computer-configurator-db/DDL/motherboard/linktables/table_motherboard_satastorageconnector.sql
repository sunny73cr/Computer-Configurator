CREATE TABLE motherboard_satastorageconnector (
	MotherboardId integer NOT NULL PRIMARY KEY REFERENCES motherboard(PartId) ON DELETE CASCADE,
	Count integer NOT NULL CHECK (Count > 0 AND Count < 20)
);