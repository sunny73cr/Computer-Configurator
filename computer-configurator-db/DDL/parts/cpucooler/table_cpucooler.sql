CREATE TABLE cpucooler (
    UUID uuid NOT NULL,
    TDPRating integer NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (UUID) REFERENCES part(UUID),
    CONSTRAINT cpucooler_tdprating_range CHECK (TDPRating > 0 AND TDPRating <= 1000)
);