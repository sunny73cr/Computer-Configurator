CREATE TABLE motherboard_usbport (
    MotherboardPartUUID uuid NOT NULL,
    USBPortUUID uuid NOT NULL,
    ExternalCount integer NOT NULL DEFAULT 0,
    InternalCount integer NOT NULL DEFAULT 0,
    PRIMARY KEY (MotherboardPartUUID, USBPortUUID),
    FOREIGN KEY (MotherboardPartUUID) REFERENCES motherboard(PartUUID),
    FOREIGN KEY (USBPortUUID) REFERENCES usbport(UUID),
    CONSTRAINT motherboard_usbport_externalcount_limit CHECK (ExternalCount <= 16),
    CONSTRAINT motherboard_usbport_internalcount_limit CHECK (ExternalCount <= 16),
    CONSTRAINT motherboard_usbport_count_noemptyentries CHECK (ExternalCount > 0 OR InternalCount > 0)
);