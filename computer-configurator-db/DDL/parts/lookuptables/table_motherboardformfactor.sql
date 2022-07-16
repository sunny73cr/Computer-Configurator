CREATE TABLE motherboardformfactor (
    UUID uuid NOT NULL,
    FormFactor varchar(30) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT motherboardformfactor_formfactor_unique UNIQUE (FormFactor),
    CONSTRAINT motherboardformfactor_formfactor_length CHECK (length(FormFactor) > 0 AND length(FormFactor) <= 30)
);