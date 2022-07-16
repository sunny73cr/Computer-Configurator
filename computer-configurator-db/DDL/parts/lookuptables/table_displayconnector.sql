CREATE TABLE displayconnector (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Interface varchar(15) NOT NULL,
    Version varchar(15) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT displayconnector_interface_version_unique UNIQUE (Interface, Version),
    CONSTRAINT displayconnector_interface_length CHECK (length(Interface) > 0 AND length(Interface) <= 15),
    CONSTRAINT displayconnector_version_length CHECK (length(Version) > 0 AND length(Version) <= 15)
);