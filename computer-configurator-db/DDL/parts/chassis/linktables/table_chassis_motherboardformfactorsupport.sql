CREATE TABLE chassis_motherboardformfactorsupport (
    ChassisPartUUID uuid NOT NULL,
    MotherboardFormFactorUUID uuid NOT NULL,
    PRIMARY KEY (ChassisPartUUID, MotherboardFormFactorUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (MotherboardFormFactorUUID) REFERENCES motherboardformfactor(UUID)
);