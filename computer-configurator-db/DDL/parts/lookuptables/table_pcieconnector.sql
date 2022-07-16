CREATE TABLE pcieconnector (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    PCIEGenerationUUID uuid NOT NULL,
    LaneCount integer NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (PCIEGenerationUUID) REFERENCES pciegeneration(UUID),
    CONSTRAINT pcieconnector_lanecount_unique UNIQUE (PCIEGenerationUUID, LaneCount),
    CONSTRAINT pcieconnector_lanecount_range CHECK (LaneCount > 0 AND LaneCount <= 16)
);