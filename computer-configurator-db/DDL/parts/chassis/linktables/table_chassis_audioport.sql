CREATE TABLE chassis_audioport (
    ChassisPartUUID uuid NOT NULL,
    AudioPortUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    PRIMARY KEY (ChassisPartUUID, AudioPortUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (AudioPortUUID) REFERENCES audioport(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID)
);