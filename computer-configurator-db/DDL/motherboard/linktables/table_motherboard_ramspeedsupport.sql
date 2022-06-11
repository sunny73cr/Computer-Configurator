CREATE TABLE motherboard_ramspeedsupport (
	MotherboardId integer NOT NULL REFERENCES motherboard(PartId) ON DELETE CASCADE,
	RamSpeedSupportId integer NOT NULL REFERENCES ramspeedsupport(Id) ON DELETE CASCADE,
	PRIMARY KEY (MotherboardId, RamSpeedSupportId)
);