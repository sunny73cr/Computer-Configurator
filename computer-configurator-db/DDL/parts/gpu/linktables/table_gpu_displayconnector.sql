CREATE TABLE gpu_displayconnector (
    GPUUUID uuid NOT NULL,
    DisplayConnectorUUID uuid NOT NULL,
    Count integer NOT NULL,
    PRIMARY KEY (GPUUUID),
    FOREIGN KEY (GPUUUID) REFERENCES gpu(UUID),
    FOREIGN KEY (DisplayConnectorUUID) REFERENCES displayconnector(UUID),
    CONSTRAINT gpu_displayconnector_count_range CHECK (Count > 0 AND Count <= 6)
);