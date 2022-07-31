CREATE TABLE motherboardchipset (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    CPUSocketUUID uuid NOT NULL,
    ManufacturerUUID uuid NOT NULL,
    Version varchar(20) NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID),
    FOREIGN KEY (ManufacturerUUID) REFERENCES manufacturer(UUID),
    CONSTRAINT motherboardchipset_manufacturer_version_unique UNIQUE (ManufacturerUUID, Version),
    CONSTRAINT motherboardchipset_version_length CHECK (length(Version) > 0 AND length(Version) <= 20)
);