CREATE TABLE system_fan (
    SystemUUID uuid NOT NULL,
    FanUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    FanCount integer NOT NULL,
    AirPressure boolean NOT NULL,
    PRIMARY KEY (SystemUUID),
    FOREIGN KEY (SystemUUID) REFERENCES system(UUID),
    FOREIGN KEY (FanUUID) REFERENCES fan(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT system_fan_fancount_range CHECK (FanCount > 0 AND FanCount <= 5)
);