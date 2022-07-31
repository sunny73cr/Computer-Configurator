CREATE TABLE motherboard_nvmeconnector (
    MotherboardUUID uuid NOT NULL,
    PCIEGenerationUUID uuid NOT NULL,
    NVMEInterfaceUUID uuid NOT NULL,
    NVMEFormFactorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (MotherboardUUID, PCIEGenerationUUID, NVMEInterfaceUUID, NVMEFormFactorUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (PCIEGenerationUUID) REFERENCES pciegeneration(UUID),
    FOREIGN KEY (NVMEInterfaceUUID) REFERENCES nvmeinterface(UUID),
    FOREIGN KEY (NVMEFormFactorUUID) REFERENCES nvmeformfactor(UUID),
    CONSTRAINT motherboard_nvmeconnector_count_range CHECK (Count > 0 AND Count <= 8)
);