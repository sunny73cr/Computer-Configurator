CREATE TABLE systembenchmark (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    SystemUUID uuid NOT NULL,
    TimestampCreated timestamptz NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    AuthorAccountUUID uuid NOT NULL,
    Notes text NULL,
    PRIMARY KEY (UUID),
    FOREIGN KEY (SystemUUID) REFERENCES system(UUID),
    FOREIGN KEY (AuthorAccountUUID) REFERENCES account(UUID)
);