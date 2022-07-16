CREATE TABLE cpuheatsink (
    CPUCoolerPartUUID uuid NOT NULL,
    HeightMM integer NOT NULL,
    PRIMARY KEY (CPUCoolerPartUUID),
    FOREIGN KEY (CPUCoolerPartUUID) REFERENCES cpucooler(PartUUID),
    CONSTRAINT cpuheatsink_height_range CHECK (HeightMM > 0 AND HeightMM <= 200)
);