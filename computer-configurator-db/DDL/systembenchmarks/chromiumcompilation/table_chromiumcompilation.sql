CREATE TABLE chromiumcompilation (
    SystemBenchmarkUUID uuid NOT NULL,
    SecondsToCompile real NOT NULL,
    PRIMARY KEY (SystemBenchmarkUUID),
    FOREIGN KEY (SystemBenchmarkUUID) REFERENCES systembenchmark(UUID),
    CONSTRAINT chromiumcompilation_secondstocompile_range CHECK (SecondsToCompile > 0 AND SecondsToCompile <= 7200)
);