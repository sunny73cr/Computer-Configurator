CREATE TABLE raidmode (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Mode varchar(50) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT raidmode_mode_unique UNIQUE (Mode),
    CONSTRAINT raidmode_mode_length CHECK (length(Mode) > 0 AND length(Mode) <= 50)
);