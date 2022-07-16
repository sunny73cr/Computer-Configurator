CREATE TABLE cpusocket (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Version varchar(20) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT cpusocket_version_unique UNIQUE (Version),
    CONSTRAINT cpusocket_version_length CHECK (length(Version) > 0 AND length(Version) <= 20)
);