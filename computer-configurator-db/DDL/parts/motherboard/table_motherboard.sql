CREATE TABLE motherboard (
    PartUUID uuid NOT NULL,
    MotherboardFormFactorUUID uuid NOT NULL,
    WifiSupport boolean NOT NULL,
    MaxRAMCapacityMByte integer NOT NULL,
    MotherboardChipsetUUID uuid NOT NULL,
    CPUSocketUUID uuid NOT NULL,
    CPUSocketCount integer NOT NULL,
    PRIMARY KEY (PartUUID),
    FOREIGN KEY (PartUUID) REFERENCES part(UUID),
    FOREIGN KEY (MotherboardFormFactorUUID) REFERENCES motherboardformfactor(UUID),
    CONSTRAINT motherboard_maxramcapacitymbyte_range CHECK (MaxRAMCapacityMByte > 0 AND MaxRAMCapacityMByte <= 16384000),
    FOREIGN KEY (MotherboardChipsetUUID) REFERENCES motherboardchipset(UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID),
    CONSTRAINT motherboard_cpusocketcount_range CHECK (CPUSocketCount > 0 AND CPUSocketCount <= 4)
);