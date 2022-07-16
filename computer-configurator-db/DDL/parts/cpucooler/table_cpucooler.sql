CREATE TABLE cpucooler (
    PartUUID uuid NOT NULL,
    TDPRating integer NOT NULL,
    PRIMARY KEY (PartUUID),
    FOREIGN KEY (PartUUID) REFERENCES part(UUID),
    CONSTRAINT cpucooler_tdprating_range CHECK (TDPRating > 0 AND TDPRating <= 1000)
);