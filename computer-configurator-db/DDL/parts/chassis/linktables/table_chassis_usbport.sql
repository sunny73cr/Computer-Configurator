CREATE TABLE chassis_usbport (
    ChassisPartUUID uuid NOT NULL,
    USBPortUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (ChassisPartUUID, USBPortUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisPartUUID) REFERENCES chassis(PartUUID),
    FOREIGN KEY (USBPortUUID) REFERENCES usbport(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT chassis_usbport_count_range CHECK (Count > 0 AND Count <= 20)
);