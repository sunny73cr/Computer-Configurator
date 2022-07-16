CREATE TABLE powersupplyformfactor (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    FormFactor varchar(10),
    PRIMARY KEY (UUID),
    CONSTRAINT powersupplyformfactor_formfactor_unique UNIQUE (FormFactor),
    CONSTRAINT powersupplyformfactor_formfactor_length CHECK (length(FormFactor) > 0 AND length(FormFactor) <= 10)
);