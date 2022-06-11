CREATE TABLE account_session (
	AccountId integer NOT NULL REFERENCES account(Id),
	SessionKey uuid NOT NULL REFERENCES session(Key),
	Active bool NOT NULL,
	CONSTRAINT AccountSessionLog PRIMARY KEY (AccountId, SessionKey)
);

CREATE UNIQUE INDEX ON account_session(AccountId, SessionKey) WHERE Active;