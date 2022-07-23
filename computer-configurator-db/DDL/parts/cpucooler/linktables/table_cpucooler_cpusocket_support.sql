CREATE TABLE cpucooler_cpusocket_support (
    CPUCoolerUUID uuid NOT NULL,
    CPUSocketUUID uuid NOT NULL,
    PRIMARY KEY (CPUCoolerUUID, CPUSocketUUID),
    FOREIGN KEY (CPUCoolerUUID) REFERENCES cpucooler(UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID)
);