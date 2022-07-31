CREATE TABLE satahdd (
    StorageUUID uuid NOT NULL,
    MountedStorageFormFactorUUID uuid NOT NULL,
    SpindleRPM integer NOT NULL,
    PRIMARY KEY (StorageUUID),
    FOREIGN KEY (StorageUUID) REFERENCES storage(UUID),
    FOREIGN KEY (MountedStorageFormFactorUUID) REFERENCES mountedstorageformfactor(UUID),
    CONSTRAINT satahdd_spindlerpm_range CHECK (SpindleRPM > 0 AND SpindleRPM <= 30000)
);