CREATE TABLE motherboard_pcieconnector (
	MotherboardId integer NOT NULL REFERENCES motherboard(PartId) ON DELETE CASCADE,
	PCIEConnectorId integer NOT NULL REFERENCES pcieconnector(Id) ON DELETE CASCADE,
	Count integer NOT NULL CHECK (Count >= 1),
	PRIMARY KEY (MotherboardId, PCIEConnectorId)
);