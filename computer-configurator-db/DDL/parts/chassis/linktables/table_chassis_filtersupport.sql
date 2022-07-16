CREATE TABLE chassis_filtersupport (
    ChassisPartUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    Removeable boolean NOT NULL,
    PRIMARY KEY (ChassisPartUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID)
);