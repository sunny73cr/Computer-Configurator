CREATE TABLE gpu_displayconnector (
    GPUPartUUID uuid NOT NULL,
    DisplayConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (GPUPartUUID),
    FOREIGN KEY (GPUPartUUID) REFERENCES gpu(PartUUID),
    FOREIGN KEY (DisplayConnectorUUID) REFERENCES displayconnector(UUID),
    CONSTRAINT gpu_displayconnector_count_range CHECK (Count > 0 AND Count <= 6)
);