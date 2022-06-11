CREATE TABLE lanport (
	Id integer PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	BandwidthMBytes integer NOT NULL CHECK (BandwidthMBytes > 100 AND BandwidthMBytes < 100000)
);