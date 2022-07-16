CREATE TABLE mountedstorageformfactor (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Size varchar(15) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT mountedstorageformfactor_size_unique UNIQUE (Size),
    CONSTRAINT mountedstorageformfactor_size_length CHECK (length(Size) > 0 AND length(Size) <= 15)
);