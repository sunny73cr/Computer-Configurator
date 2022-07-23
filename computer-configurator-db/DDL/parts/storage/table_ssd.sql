CREATE TABLE ssd (
    StorageUUID uuid NOT NULL,
    MountedStorageFormFactorUUID uuid NOT NULL,
    PRIMARY KEY (StorageUUID),
    FOREIGN KEY (StorageUUID) REFERENCES storage(UUID),
    FOREIGN KEY (MountedStorageFormFactorUUID) REFERENCES mountedstorageformfactor(UUID)
);