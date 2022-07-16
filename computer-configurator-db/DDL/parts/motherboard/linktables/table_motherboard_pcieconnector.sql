CREATE TABLE motherboard_pcieconnector (
    MotherboardPartUUID uuid NOT NULL,
    PCIEConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, PCIEConnectorUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (PCIEConnectorUUID) REFERENCES pcieconnector(UUID),
    CONSTRAINT motherboard_pcieconnector_count_range CHECK (Count > 0 AND Count < 25)
);