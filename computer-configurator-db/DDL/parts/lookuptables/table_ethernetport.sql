CREATE TABLE ethernetport (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Chipset varchar(50) NOT NULL,
    BandwidthMBytes integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT ethernetport_chipset_length CHECK (length(Chipset) > 0 AND length(Chipset) < 50),
    CONSTRAINT ethernetport_bandwidth_range CHECK (BandwidthMBytes > 100 AND BandwidthMBytes < 200000)
);