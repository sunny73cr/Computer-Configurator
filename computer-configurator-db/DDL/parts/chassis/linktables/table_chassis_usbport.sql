CREATE TABLE chassis_usbport (
    ChassisUUID uuid NOT NULL,
    USBPortUUID uuid NOT NULL,
    ChassisZoneUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (ChassisUUID, USBPortUUID, ChassisZoneUUID),
    FOREIGN KEY (ChassisUUID) REFERENCES chassis(UUID),
    FOREIGN KEY (USBPortUUID) REFERENCES usbport(UUID),
    FOREIGN KEY (ChassisZoneUUID) REFERENCES chassiszone(UUID),
    CONSTRAINT chassis_usbport_count_range CHECK (Count > 0 AND Count <= 20)
);