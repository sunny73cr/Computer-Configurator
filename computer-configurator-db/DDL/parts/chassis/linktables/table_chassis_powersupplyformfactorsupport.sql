CREATE TABLE chassis_powersupplyformfactorsupport (
    ChassisPartUUID uuid NOT NULL,
    PSUFormFactorUUID uuid NOT NULL,
    BracketRequired boolean NOT NULL,
    PRIMARY KEY (ChassisPartUUID, PSUFormFactorUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (PSUFormFactorUUID) REFERENCES powersupplyformfactor(UUID)
);