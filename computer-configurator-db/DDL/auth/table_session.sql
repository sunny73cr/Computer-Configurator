CREATE TABLE session (
    Key uuid NOT NULL DEFAULT gen_random_uuid(),
    AccountUUID uuid NOT NULL,
    LoginTimestamp timestamptz NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    LogoutTimestamp timestamptz NULL,
    PRIMARY KEY (Key),
    FOREIGN KEY (AccountUUID) REFERENCES account(UUID)
);