CREATE TABLE nvmeformfactor (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    FormFactor varchar(10) NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT nvmeformfactor_formfactor_unique UNIQUE (FormFactor),
    CONSTRAINT nvmeformfactor_formfactor_length CHECK (length(FormFactor) > 0 AND length(FormFactor) <= 10)
);