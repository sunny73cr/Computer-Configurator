CREATE TABLE chassis_powersupplyformfactorsupport (
    ChassisUUID uuid NOT NULL,
    PowerSupplyFormFactorUUID uuid NOT NULL,
    BracketRequired boolean NOT NULL,
    PRIMARY KEY (ChassisUUID, PowerSupplyFormFactorUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (PowerSupplyFormFactorUUID) REFERENCES powersupplyformfactor(UUID)
);