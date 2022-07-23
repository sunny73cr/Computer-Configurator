CREATE TABLE cpucooler_fan (
    CPUCoolerUUID uuid NOT NULL,
    FanUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (CPUCoolerUUID, FanUUID),
    FOREIGN KEY (CPUCoolerUUID) REFERENCES cpucooler(UUID),
    FOREIGN KEY (FanUUID) REFERENCES fan(UUID),
    CONSTRAINT cpucooler_fan_count_range CHECK (Count > 0 AND Count <= 8)
);