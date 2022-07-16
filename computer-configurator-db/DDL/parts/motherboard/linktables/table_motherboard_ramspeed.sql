CREATE TABLE motherboard_ramspeed (
    MotherboardPartUUID uuid NOT NULL,
    RAMSpeedUUID uuid NOT NULL,
    RequiresOverclock boolean NOT NULL,
    PRIMARY KEY (MotherboardPartUUID, RAMSpeedUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (RAMSpeedUUID) REFERENCES ramspeed(UUID)
);