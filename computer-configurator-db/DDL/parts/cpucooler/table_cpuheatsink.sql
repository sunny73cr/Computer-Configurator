CREATE TABLE cpuheatsink (
    CPUCoolerUUID uuid NOT NULL,
    HeightMM integer NOT NULL,
    PRIMARY KEY (CPUCoolerUUID),
    FOREIGN KEY (CPUCoolerUUID) REFERENCES cpucooler(UUID),
    CONSTRAINT cpuheatsink_height_range CHECK (HeightMM > 0 AND HeightMM <= 200)
);