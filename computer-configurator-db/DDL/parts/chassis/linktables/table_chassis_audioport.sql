CREATE TABLE chassis_audioport (
    ChassisUUID uuid NOT NULL,
    AudioPortUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    PRIMARY KEY (ChassisUUID, AudioPortUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (AudioPortUUID) REFERENCES audioport(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID)
);