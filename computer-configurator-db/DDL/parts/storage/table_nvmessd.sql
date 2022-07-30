CREATE TABLE nvmessd (
    StorageUUID uuid NOT NULL,
    NVMEFormFactorUUID uuid NOT NULL,
    NVMEInterfaceUUID uuid NOT NULL,
    PRIMARY KEY (StorageUUID),
    FOREIGN KEY (StorageUUID) REFERENCES storage(UUID),
    FOREIGN KEY (NVMEFormFactorUUID) REFERENCES nvmeformfactor(UUID),
    FOREIGN KEY (NVMEInterfaceUUID) REFERENCES nvmeinterface(UUID)
);