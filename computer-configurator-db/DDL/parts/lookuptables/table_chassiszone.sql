CREATE TABLE chassiszone (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Zone varchar(50) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT chassiszone_zone_unique UNIQUE (Zone),
    CONSTRAINT chassiszone_zone_length CHECK (length(Zone) > 0 AND length(Zone) <= 50)
);