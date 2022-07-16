CREATE TABLE fandiameter (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Diameter integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT fandiameter_diameter_unique UNIQUE (Diameter),
    CONSTRAINT fandiameter_diameter_range CHECK (Diameter >= 40 AND Diameter <= 400)
);