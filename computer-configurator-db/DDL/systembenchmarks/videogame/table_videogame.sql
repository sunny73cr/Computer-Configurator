CREATE TABLE videogame (
    SystemBenchmarkUUID uuid NOT NULL,
    Name varchar(100) NOT NULL,
    BenchmarkedResolutionUUID uuid NOT NULL,
    FPSPointOneLow real NOT NULL,
    FPSOneLow real NOT NULL,
    FPSAverage real NOT NULL,
    PRIMARY KEY (SystemBenchmarkUUID),
    FOREIGN KEY (SystemBenchmarkUUID) REFERENCES systembenchmark(UUID),
    CONSTRAINT videogame_name_length CHECK (length(Name) > 0 AND length(Name) <= 100),
    FOREIGN KEY (BenchmarkedResolutionUUID) REFERENCES benchmarkedresolution(UUID),
    CONSTRAINT videogame_fpspointonelow_range CHECK (FPSPointOneLow > 0 AND FPSPointOneLow <= 1000),
    CONSTRAINT videogame_fpsonelow_range CHECK (FPSOneLow > FPSPointOneLow AND FPSOneLow <= 1000),
    CONSTRAINT videogame_fpsaverage_range CHECK (FPSAverage > FPSOneLow AND FPSAverage <= 1000)
);