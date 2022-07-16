CREATE TABLE cpucooler_cpusocket_support (
    CPUCoolerPartUUID uuid NOT NULL,
    CPUSocketUUID uuid NOT NULL,
    PRIMARY KEY (CPUCoolerPartUUID, CPUSocketUUID),
    FOREIGN KEY (CPUCoolerPartUUID) REFERENCES cpucooler(PartUUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID)
);