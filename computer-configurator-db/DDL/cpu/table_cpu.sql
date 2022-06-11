CREATE TABLE cpu (
	PartId integer NOT NULL PRIMARY KEY REFERENCES part(Id),
	SocketType cpusockettype NOT NULL,
	CoreCount integer NOT NULL CHECK (CoreCount >= 1 AND CoreCount <=512),
	ThreadCount integer NOT NULL CHECK (ThreadCount >= CoreCount AND ThreadCount <= 1024),
	BaseClockSpeed integer NOT NULL CHECK (BaseClockSpeed >= 800 AND BaseClockSpeed <= 7000),
	BoostClockSpeed integer CHECK (BoostClockSpeed >= BaseClockSpeed AND BoostClockSpeed < 10000)
);