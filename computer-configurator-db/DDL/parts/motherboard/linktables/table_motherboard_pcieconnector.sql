CREATE TABLE motherboard_pcieconnector (
    MotherboardUUID uuid NOT NULL,
    PCIEConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, PCIEConnectorUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (PCIEConnectorUUID) REFERENCES pcieconnector(UUID),
    CONSTRAINT motherboard_pcieconnector_count_range CHECK (Count > 0 AND Count < 25)
);