CREATE TABLE motherboard_ramsocket (
    MotherboardUUID uuid NOT NULL,
    RAMSocketUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, RAMSocketUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (RAMSocketUUID) REFERENCES ramsocket(UUID),
    CONSTRAINT motherboard_ramsocket_count_range CHECK (Count > 0 AND Count <= 16)
);