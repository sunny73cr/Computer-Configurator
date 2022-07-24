CREATE TABLE audioport (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    PinCount integer NOT NULL,
    ConnectorSize real NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT audioport_pincount_connectorsize_unique UNIQUE (PinCount, ConnectorSize),
    CONSTRAINT audioport_pincount_range CHECK (PinCount > 0 AND PinCount <= 10),
    CONSTRAINT audioport_connectorsize_range CHECK (ConnectorSize > 0 AND ConnectorSize <= 10)
);