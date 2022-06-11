CREATE TABLE session (
	Key uuid NOT NULL PRIMARY KEY DEFAULT gen_random_uuid(),
	LoginTimesamp timestamptz NOT NULL DEFAULT transaction_timestamp(), 
	LogoutTimestamp timestamptz NULL,
	Active bool GENERATED ALWAYS AS (LogoutTimestamp != NULL) STORED,
	Unique(Key)
);
