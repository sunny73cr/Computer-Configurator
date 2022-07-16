CREATE TABLE manufacturer (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Name varchar(50) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT manufacturer_name_unique UNIQUE (Name),
    CONSTRAINT manufacturer_name_length CHECK (length(Name) > 0 AND length(Name) <= 50)
);