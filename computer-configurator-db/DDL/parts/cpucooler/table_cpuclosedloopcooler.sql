CREATE TABLE cpuclosedloopcooler (
    CPUCoolerPartUUID uuid NOT NULL,
    RadiatorSizeUUID uuid NOT NULL,
    PRIMARY KEY (CPUCoolerPartUUID),
    FOREIGN KEY (CPUCoolerPartUUID) REFERENCES cpucooler(PartUUID),
    FOREIGN KEY (RadiatorSizeUUID) REFERENCES radiatorsize(UUID)
);