CREATE TABLE ethernetport (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Chispset varchar(50) NOT NULL,
    BandwidthMBytes integer NOT NULL,
    PRIMARY KEY (UUID),
    CONSTRAINT ethernetport_chipset_length CHECK (length(Chispset) > 0 AND length(Chispset) < 50),
    CONSTRAINT ethernetport_bandwidth_range CHECK (BandwidthMBytes > 100 AND BandwidthMBytes < 200000)
);