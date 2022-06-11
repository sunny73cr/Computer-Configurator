CREATE TABLE motherboard_nvmestorageconnector (
	MotherboardId integer NOT NULL PRIMARY KEY REFERENCES motherboard(PartId) ON DELETE CASCADE,
	MinimumSupportedLength nvmestorageconnectorlength NOT NULL,
	MaximumSupportedLength nvmestorageconnectorlength NOT NULL,
	Count integer NOT NULL CHECK (Count > 0 AND Count < 20)
);