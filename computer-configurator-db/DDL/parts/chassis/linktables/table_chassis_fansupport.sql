CREATE TABLE chassis_fansupport (
    ChassisUUID uuid NOT NULL,
    FanDiameterUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    MaximumWidthMM integer NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (ChassisUUID, FanDiameterUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (FanDiameterUUID) REFERENCES fandiameter(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT chassis_fansupport_maximumwidth_range CHECK (MaximumWidthMM >= 10 AND MaximumWidthMM <= 30),
    CONSTRAINT chassis_fansupport_count_range CHECK (Count > 0 AND Count <= 5)
);