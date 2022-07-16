CREATE TABLE motherboardchipset (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    CPUSocketUUID uuid NOT NULL,
    Manufacturer varchar(50) NOT NULL,
    Version varchar(20) NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID),
    CONSTRAINT motherboardchipset_manufacturer_version_unique UNIQUE (Manufacturer, Version),
    CONSTRAINT motherboardchipset_manufacturer_length CHECK (length(Manufacturer) > 0 AND length(Manufacturer) <= 50),
    CONSTRAINT motherboardchipset_version_length CHECK (length(Version) > 0 AND length(Version) <= 20)
);