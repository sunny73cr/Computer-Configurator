CREATE TABLE motherboard_ethernetport (
    MotherboardPartUUID uuid NOT NULL,
    EthernetPortUUID uuid NOT NULL,
    Count integer NOT NULL DEFAULT 1,
    PRIMARY KEY (MotherboardPartUUID, EthernetPortUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (EthernetPortUUID) REFERENCES ethernetport(UUID),
    CONSTRAINT motherboard_ethernetport_count_range CHECK (Count > 0 AND Count < 8)
);