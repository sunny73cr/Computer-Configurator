CREATE TABLE motherboard (
	PartId integer NOT NULL PRIMARY KEY REFERENCES part(Id),
	Size motherboardformfactor NOT NULL,
	ChipsetId integer NOT NULL REFERENCES chipset(Id),
	MotherboardSocketId integer NOT NULL REFERENCES motherboardsocket(Id),
	WifiSupport boolean NOT NULL,
	RAMSocketId integer NOT NULL REFERENCES ramsocket(Id),
	RAMSocketCount integer NOT NULL CHECK (
		RAMSocketCount > 0 AND
		RAMSocketCount < 64 AND
		MOD(RAMSocketCount, 2) = 0  -- Even number of RAM slots
	),
	MaxRAMCapacityMByte integer
);