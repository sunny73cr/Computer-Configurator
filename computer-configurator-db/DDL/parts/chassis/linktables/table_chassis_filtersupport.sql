CREATE TABLE chassis_filtersupport (
    ChassisUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    Removeable boolean NOT NULL,
    PRIMARY KEY (ChassisUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID)
);