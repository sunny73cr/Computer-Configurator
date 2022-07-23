CREATE TABLE chassis (
    UUID uuid NOT NULL,
    LengthMM integer NOT NULL,
    WidthMM integer NOT NULL,
    HeightMM integer NOT NULL,
    MaxGPULengthMM integer NOT NULL,
    MaxPSULengthMM integer NOT NULL,
    MaxCPUCoolerHeightMM integer NOT NULL,
    PCIESlotCount integer NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (UUID) REFERENCES part(UUID),
    CONSTRAINT chassis_length_range CHECK (LengthMM > 0 AND LengthMM <= 1000),
    CONSTRAINT chassis_width_range CHECK (WidthMM > 0 AND WidthMM <= 1000),
    CONSTRAINT chassis_height_range CHECK (HeightMM > 0 AND HeightMM <= 1000),
    CONSTRAINT chassis_maxgpulength_range CHECK (MaxGPULengthMM > 100 AND MaxGPULengthMM <= 350),
    CONSTRAINT chassis_maxpsulength_range CHECK (MaxPSULengthMM > 100 AND MaxPSULengthMM <= 240),
    CONSTRAINT chassis_maxcpucoolerheight_range CHECK (MaxCPUCoolerHeightMM > 30 AND MaxCPUCoolerHeightMM <= 210),
    CONSTRAINT chassis_pcieslotcount_range CHECK (PCIESlotCount > 0 AND PCIESlotCount <= 10)
);