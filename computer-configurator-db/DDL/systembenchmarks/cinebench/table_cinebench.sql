CREATE TABLE cinebench (
    SystemBenchmarkUUID uuid NOT NULL,
    SingleThreadScore integer NOT NULL,
    MultiThreadScore integer NOT NULL,
    PRIMARY KEY (SystemBenchmarkUUID),
    FOREIGN KEY (SystemBenchmarkUUID) REFERENCES systembenchmark(UUID),
    CONSTRAINT cinebench_singlethreadscore_range CHECK (SingleThreadScore > 0 AND SingleThreadScore <= 6000),
    CONSTRAINT cinebench_multithreadscore_range CHECK (MultiThreadScore >= SingleThreadScore AND MultiThreadScore <= 250000)
);