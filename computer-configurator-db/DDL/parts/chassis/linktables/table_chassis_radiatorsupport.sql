CREATE TABLE chassis_radiatorsupport (
    ChassisPartUUID uuid NOT NULL,
    RadiatorSizeUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    MaximumWidthMM integer NOT NULL,
    PRIMARY KEY (ChassisPartUUID, RadiatorSizeUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (RadiatorSizeUUID) REFERENCES radiatorsize(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT chassis_radiatorsupport_maximumwidth_range CHECK (MaximumWidthMM > 20 AND MaximumWidthMM <= 60)
);