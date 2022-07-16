CREATE TABLE radiatorsize (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Size integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT radiatorsize_size_unique UNIQUE (Size),
    CONSTRAINT radiatorsize_size_range CHECK (Size >= 120 AND Size <= 1080)
);