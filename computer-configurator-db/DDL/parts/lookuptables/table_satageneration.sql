CREATE TABLE satageneration (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Generation varchar(10) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT satageneration_generation_unique UNIQUE (Generation),
    CONSTRAINT satageneration_generation_length CHECK (length(Generation) > 0 AND length(Generation) <= 10)
);