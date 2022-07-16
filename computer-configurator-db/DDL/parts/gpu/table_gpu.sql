CREATE TABLE gpu (
    PartUUID uuid NOT NULL,
    PCIEConnectorUUID uuid NOT NULL,
    VRAMMBytes integer NOT NULL,
    BaseClockSpeed integer NOT NULL,
    BoostClockSpeed integer NULL,
    MaxDisplayCount integer NOT NULL,
    LengthMM integer NOT NULL,
    WidthMM integer NOT NULL,
    HeightMM integer NOT NULL,
    SlotWidth real NOT NULL,
    PRIMARY KEY (PartUUID),
    FOREIGN KEY (PartUUID) REFERENCES part(UUID),
    FOREIGN KEY (PCIEConnectorUUID) REFERENCES pcieconnector(UUID),
    CONSTRAINT gpu_vrammbytes_range CHECK (VRAMMBytes > 1024 AND VRAMMBytes <= 49512),
    CONSTRAINT gpu_baseclockspeed_range CHECK (BaseClockSpeed > 500 AND BaseClockSpeed <= 2800),
    CONSTRAINT gpu_boostclockspeed_range CHECK (BoostClockSpeed > 800 AND BoostClockSpeed <= 2800),
    CONSTRAINT gpu_maxdisplaycount_range CHECK (MaxDisplayCount > 0 AND MaxDisplayCount <= 8),
    CONSTRAINT gpu_length_range CHECK (LengthMM > 120 AND LengthMM <= 350),
    CONSTRAINT gpu_width_range CHECK (WidthMM > 30 AND WidthMM <= 102),
    CONSTRAINT gpu_height_range CHECK (HeightMM > 60 AND HeightMM <= 112),
    CONSTRAINT gpu_slotwidth_range CHECK (SlotWidth > 0 AND SlotWidth <= 5)
);