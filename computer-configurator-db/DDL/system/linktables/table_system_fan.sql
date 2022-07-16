CREATE TABLE system_fan (
    SystemUUID uuid NOT NULL,
    FanPartUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    FanCount integer NOT NULL,
    AirPressure boolean NOT NULL,
    PRIMARY KEY (SystemUUID),
    FOREIGN KEY (SystemUUID) REFERENCES system(UUID),
    FOREIGN KEY (FanPartUUID) REFERENCES fan(PartUUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT system_fan_fancount_range CHECK (FanCount > 0 AND FanCount <= 5)
);