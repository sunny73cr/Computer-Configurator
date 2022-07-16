CREATE TABLE pugetbench (
    SystemBenchmarkUUID uuid NOT NULL,
    Name varchar(30) NOT NULL,
    Version varchar(30) NOT NULL,
    Score real NOT NULL,
    PRIMARY KEY (SystemBenchmarkUUID),
    FOREIGN KEY (SystemBenchmarkUUID) REFERENCES systembenchmark(UUID),
    CONSTRAINT pugetbench_name_length CHECK (length(Name) > 0 AND length(Name) <= 30),
    CONSTRAINT pugetbench_version_length CHECK (length(Version) > 0 AND length(Version) <= 30),
    CONSTRAINT pugetbench_score_range CHECK (Score > 0 AND Score <= 10000)
);