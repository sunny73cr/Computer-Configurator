CREATE TABLE cpucooler_fan (
    CPUCoolerPartUUID uuid NOT NULL,
    FanPartUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (CPUCoolerPartUUID, FanPartUUID),
    FOREIGN KEY (CPUCoolerPartUUID) REFERENCES cpucooler(PartUUID),
    FOREIGN KEY (FanPartUUID) REFERENCES fan(PartUUID),
    CONSTRAINT cpucooler_fan_count_range CHECK (Count > 0 AND Count <= 8)
);