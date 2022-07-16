CREATE TABLE motherboard_nvmeconnector (
    MotherboardPartUUID uuid NOT NULL,
    PCIEGenerationUUID uuid NOT NULL,
    NVMEInterfaceUUID uuid NOT NULL,
    NVMEFormFactorUUId uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, PCIEGenerationUUID, NVMEInterfaceUUID, NVMEFormFactorUUId),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (PCIEGenerationUUID) REFERENCES pciegeneration(UUID),
    FOREIGN KEY (NVMEInterfaceUUID) REFERENCES nvmeinterface(UUID),
    FOREIGN KEY (NVMEFormFactorUUId) REFERENCES nvmeformfactor(UUID),
    CONSTRAINT motherboard_nvmeconnector_count_range CHECK (Count > 0 AND Count <= 8)
);