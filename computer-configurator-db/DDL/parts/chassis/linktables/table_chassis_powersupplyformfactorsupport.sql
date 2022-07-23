CREATE TABLE chassis_powersupplyformfactorsupport (
    ChassisUUID uuid NOT NULL,
    PSUFormFactorUUID uuid NOT NULL,
    BracketRequired boolean NOT NULL,
    PRIMARY KEY (ChassisUUID, PSUFormFactorUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (PSUFormFactorUUID) REFERENCES powersupplyformfactor(UUID)
);