CREATE TABLE hdd (
    StoragePartUUID uuid NOT NULL,
    MountedStorageFormFactorUUID uuid NOT NULL,
    SpindleRPM integer NOT NULL,
    PRIMARY KEY (StoragePartUUID),
    FOREIGN KEY (StoragePartUUID) REFERENCES storage(PartUUID),
    FOREIGN KEY (MountedStorageFormFactorUUID) REFERENCES mountedstorageformfactor(UUID),
    CONSTRAINT hdd_spindlerpm_range CHECK (SpindleRPM > 0 AND SpindleRPM <= 30000)
);