CREATE TABLE motherboard_fanheader (
    MotherboardUUID uuid NOT NULL,
    FanHeaderUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, FanHeaderUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (FanHeaderUUID) REFERENCES fanheader(UUID),
    CONSTRAINT motherboard_fanheader_count_range CHECK (Count > 0 AND Count <= 12)
);