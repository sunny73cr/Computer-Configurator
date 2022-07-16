CREATE TABLE eightyplusrating (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Rating varchar(20) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT eightyplusrating_rating_unique UNIQUE (Rating),
    CONSTRAINT eightyplusrating_rating_length CHECK (length(Rating) > 0 AND length(Rating) <= 20)
);