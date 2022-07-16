CREATE TABLE cpu (
    PartUUID uuid NOT NULL,
    CPUSocketUUID uuid NOT NULL,
    CoreCount integer NOT NULL,
    ThreadCount integer NOT NULL,
    BaseClockSpeedMHZ integer NOT NULL,
    BoostClockSpeedMHZ integer NULL,
    PRIMARY KEY (PartUUID),
    FOREIGN KEY (PartUUID) REFERENCES part(UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID),
    CONSTRAINT cpu_corecount_range CHECK (CoreCount > 0 AND CoreCount <= 512),
    CONSTRAINT cpu_threadcount_range CHECK (ThreadCount >= CoreCount AND ThreadCount <= 1024),
    CONSTRAINT cpu_baseclockspeed_range CHECK (BaseClockSpeedMHZ >= 800 AND BaseClockSpeedMHZ <= 7000),
    CONSTRAINT cpu_boostclockspeed_range CHECK (BoostClockSpeedMHZ >= BaseClockSpeedMHZ AND BoostClockSpeedMHZ <= 7000)
);