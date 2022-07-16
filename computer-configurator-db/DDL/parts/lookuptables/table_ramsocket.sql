CREATE TABLE ramsocket (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Version varchar(15) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT ramsocket_version_unique UNIQUE(Version),
    CONSTRAINT ramsocket_version_length CHECK (length(Version) > 0 AND length(Version) <= 15)
);