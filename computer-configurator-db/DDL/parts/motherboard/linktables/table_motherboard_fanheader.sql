CREATE TABLE motherboard_fanheader (
    MotherboardPartUUID uuid NOT NULL,
    FanHeaderUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, FanHeaderUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (FanHeaderUUID) REFERENCES fanheader(UUID),
    CONSTRAINT motherboard_fanheader_count_range CHECK (Count > 0 AND Count <= 12)
);