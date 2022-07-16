CREATE TABLE pciegeneration (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Generation varchar(15),
    PRIMARY KEY (UUID),
    CONSTRAINT pciegeneration_generation_unique UNIQUE (Generation),
    CONSTRAINT pciegeneration_generation_length CHECK (length(Generation) > 0 AND length(Generation) <= 15)
);