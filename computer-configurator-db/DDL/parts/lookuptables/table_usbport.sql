CREATE TABLE usbport (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Interface varchar(15) NOT NULL,
    Version varchar(15) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT usbport_interface_version_unique UNIQUE (Interface, Version),
    CONSTRAINT usbport_interface_length CHECK (length(Interface) > 0 AND length(Interface) <= 15),
    CONSTRAINT usbport_version_length CHECK (length(Version) > 0 AND length(Version) <= 15)
);