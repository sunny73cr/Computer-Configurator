CREATE TABLE systemraid (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    RAIDModeUUID uuid NOT NULL,
    StorageCount integer NOT NULL,
    ParityDiskCount integer NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (RAIDModeUUID) REFERENCES raidmode(UUID),
    CONSTRAINT systemraid_storagecount_range CHECK (StorageCount > 0 AND StorageCount <= 48),
    CONSTRAINT systemraid_paritydiskcount_range CHECK (ParityDiskCount >= 0 AND ParityDiskCount <= 18)
);