CREATE TABLE motherboard_ethernetport (
    MotherboardUUID uuid NOT NULL,
    EthernetPortUUID uuid NOT NULL,
    Count integer NOT NULL DEFAULT 1,
    PRIMARY KEY (MotherboardUUID, EthernetPortUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (EthernetPortUUID) REFERENCES ethernetport(UUID),
    CONSTRAINT motherboard_ethernetport_count_range CHECK (Count > 0 AND Count < 8)
);