CREATE TABLE motherboard_ramspeed (
    MotherboardUUID uuid NOT NULL,
    RAMSpeedUUID uuid NOT NULL,
    RequiresOverclock boolean NOT NULL,
    PRIMARY KEY (MotherboardUUID, RAMSpeedUUID),
    FOREIGN KEY (MotherboardUUID) REFERENCES motherboard(UUID),
    FOREIGN KEY (RAMSpeedUUID) REFERENCES ramspeed(UUID)
);