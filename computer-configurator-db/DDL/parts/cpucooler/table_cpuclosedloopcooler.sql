CREATE TABLE cpuclosedloopcooler (
    CPUCoolerUUID uuid NOT NULL,
    RadiatorSizeUUID uuid NOT NULL,
    PRIMARY KEY (CPUCoolerUUID),
    FOREIGN KEY (CPUCoolerUUID) REFERENCES cpucooler(UUID),
    FOREIGN KEY (RadiatorSizeUUID) REFERENCES radiatorsize(UUID)
);