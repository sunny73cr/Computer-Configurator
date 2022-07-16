CREATE TABLE motherboard_sataconnector (
    MotherboardPartUUID uuid NOT NULL,
    SATAGenerationUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, SATAGenerationUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (SATAGenerationUUID) REFERENCES satageneration(UUID),
    CONSTRAINT motherboard_sataconnector_count_range CHECK (Count > 0 AND Count <= 16)
);