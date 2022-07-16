CREATE TABLE nvmeinterface (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Interface varchar(10) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT nvmeinterface_interface_unique UNIQUE (Interface),
    CONSTRAINT nvmeinterface_interface_length CHECK (length(Interface) > 0 AND length(Interface) <= 10)
);