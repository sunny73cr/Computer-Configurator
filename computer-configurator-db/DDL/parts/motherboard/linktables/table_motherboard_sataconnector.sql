CREATE TABLE motherboard_sataconnector (
    MotherboardUUID uuid NOT NULL,
    SATAGenerationUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, SATAGenerationUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (SATAGenerationUUID) REFERENCES satageneration(UUID),
    CONSTRAINT motherboard_sataconnector_count_range CHECK (Count > 0 AND Count <= 16)
);