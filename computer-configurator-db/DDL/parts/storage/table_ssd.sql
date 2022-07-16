CREATE TABLE ssd (
    StoragePartUUID uuid NOT NULL,
    MountedStorageFormFactorUUID uuid NOT NULL,
    PRIMARY KEY (StoragePartUUID),
    FOREIGN KEY (StoragePartUUID) REFERENCES storage(PartUUID),
    FOREIGN KEY (MountedStorageFormFactorUUID) REFERENCES mountedstorageformfactor(UUID)
);