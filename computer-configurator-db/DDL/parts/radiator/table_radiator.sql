CREATE TABLE radiator(
    UUID uuid NOT NULL,
    WidthMM integer NOT NULL,
    RadiatorSizeUUID uuid NOT NULL,
    TubeInnerDiameterMM real NOT NULL,
    TubeOuterDiameterMM real NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (UUID) REFERENCES part(UUID),
    CONSTRAINT radiator_widthmm_range CHECK (WidthMM > 25 AND WidthMM < 80),
    FOREIGN KEY (RadiatorSizeUUID) REFERENCES radiatorsize(UUID),
    CONSTRAINT radiator_tubeinnerdiameter_range CHECK (TubeInnerDiameterMM > 0 AND TubeInnerDiameterMM <= 20),
    CONSTRAINT radiator_tubeouterdiameter_range CHECK (TubeOuterDiameterMM > TubeInnerDiameterMM AND TubeOuterDiameterMM <= 40)
);