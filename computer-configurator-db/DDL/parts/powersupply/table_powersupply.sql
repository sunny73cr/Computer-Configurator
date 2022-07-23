CREATE TABLE powersupply (
    UUID uuid NOT NULL,
    MaximumOutputWatts integer NOT NULL,
    PowerSupplyFormFactorUUID uuid NOT NULL,
    LengthMM integer NOT NULL,
    ModularCables boolean NOT NULL,
    MTBF integer NULL,
    EightyPlusRatingUUID uuid NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (UUID) REFERENCES part(UUID),
    FOREIGN KEY (PowerSupplyFormFactorUUID) REFERENCES powersupplyformfactor(UUID),
    FOREIGN KEY (EightyPlusRatingUUID) REFERENCES eightyplusrating(UUID),
    CONSTRAINT powersupply_maximumoutputwatts_range CHECK (MaximumOutputWatts > 0 AND MaximumOutputWatts <= 2000),
    CONSTRAINT powersupply_length_range CHECK (LengthMM > 0 AND LengthMM <= 240),
    CONSTRAINT powersupply_mtbf_range CHECK (MTBF > 0 AND MTBF <= 1000000)
);