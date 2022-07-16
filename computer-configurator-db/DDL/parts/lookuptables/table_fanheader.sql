CREATE TABLE fanheader (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    PinCount integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT fanheader_pincount_unqiue UNIQUE (PinCount),
    CONSTRAINT fanheader_pincount_range CHECK (PinCount = 3 OR PinCount = 4)
);