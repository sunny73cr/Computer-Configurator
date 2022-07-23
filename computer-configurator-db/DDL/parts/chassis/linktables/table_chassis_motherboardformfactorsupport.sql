CREATE TABLE chassis_motherboardformfactorsupport (
    ChassisUUID uuid NOT NULL,
    MotherboardFormFactorUUID uuid NOT NULL,
    PRIMARY KEY (ChassisUUID, MotherboardFormFactorUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (MotherboardFormFactorUUID) REFERENCES motherboardformfactor(UUID)
);