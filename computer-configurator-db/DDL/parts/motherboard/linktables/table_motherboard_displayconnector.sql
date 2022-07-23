CREATE TABLE motherboard_displayconnector (
    MotherboardUUID uuid NOT NULL,
    DisplayConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, DisplayConnectorUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (DisplayConnectorUUID) REFERENCES displayconnector(UUID),
    CONSTRAINT motherboard_displayconnector_count_range CHECK (Count > 0 AND Count <= 4)
);