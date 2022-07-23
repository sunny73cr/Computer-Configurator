CREATE TABLE cpu (
    UUID uuid NOT NULL,
    CPUSocketUUID uuid NOT NULL,
    CoreCount integer NOT NULL,
    ThreadCount integer NOT NULL,
    BaseClockSpeed integer NOT NULL,
    BoostClockSpeed integer NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (UUID) REFERENCES part(UUID),
    FOREIGN KEY (CPUSocketUUID) REFERENCES cpusocket(UUID),
    CONSTRAINT cpu_corecount_range CHECK (CoreCount > 0 AND CoreCount <= 512),
    CONSTRAINT cpu_threadcount_range CHECK (ThreadCount >= CoreCount AND ThreadCount <= 1024),
    CONSTRAINT cpu_baseclockspeed_range CHECK (BaseClockSpeed >= 800 AND BaseClockSpeed <= 7000),
    CONSTRAINT cpu_boostclockspeed_range CHECK (BoostClockSpeed >= BaseClockSpeed AND BoostClockSpeed <= 7000)
);