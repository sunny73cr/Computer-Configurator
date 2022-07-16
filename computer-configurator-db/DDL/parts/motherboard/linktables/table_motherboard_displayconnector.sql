CREATE TABLE motherboard_displayconnector (
    MotherboardPartUUID uuid NOT NULL,
    DisplayConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, DisplayConnectorUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (DisplayConnectorUUID) REFERENCES displayconnector(UUID),
    CONSTRAINT motherboard_displayconnector_count_range CHECK (Count > 0 AND Count <= 4)
);