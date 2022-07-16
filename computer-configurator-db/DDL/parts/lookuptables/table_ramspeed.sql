CREATE TABLE ramspeed (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    ClockRate integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT ramspeed_clockrate_unique UNIQUE(ClockRate),
    CONSTRAINT ramspeed_clockrate_range CHECK (ClockRate > 800 AND ClockRate <= 14000)
);