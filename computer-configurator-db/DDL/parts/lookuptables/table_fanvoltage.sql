CREATE TABLE fanvoltage (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Voltage integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT fanvoltage_voltage_unique UNIQUE (Voltage)
);