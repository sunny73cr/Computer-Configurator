CREATE TABLE part (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    ManufacturerUUID uuid NOT NULL,
    Model varchar(50) NOT NULL,
    ShortDescription varchar(100) NOT NULL,
    LongDescription varchar(256) NULL,
    Price numeric(7,2) NOT NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (ManufacturerUUID) REFERENCES manufacturer(UUID),
    CONSTRAINT part_manufacturer_model_unique UNIQUE (ManufacturerUUID, Model),
    CONSTRAINT part_model_length CHECK (length(Model) > 0 AND length(Model) <= 50),
    CONSTRAINT part_shortdescription_length CHECK (length(ShortDescription) > 0 AND length(ShortDescription) <= 100),
    CONSTRAINT part_longdescription_length CHECK (length(LongDescription) > 0 AND length(LongDescription) <= 256),
    CONSTRAINT part_price_range CHECK (Price > 0 AND Price < 10000)
);