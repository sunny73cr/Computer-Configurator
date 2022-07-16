CREATE TABLE motherboard_ramsocket (
    MotherboardPartUUID uuid NOT NULL,
    RAMSocketUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, RAMSocketUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (RAMSocketUUID) REFERENCES ramsocket(UUID),
    CONSTRAINT motherboard_ramsocket_count_range CHECK (Count > 0 AND Count <= 16)
);