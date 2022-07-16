CREATE TABLE account (
    UUID uuid NOT NULL DEFAULT gen_random_uuid(),
    Email varchar(128) NOT NULL,
    Name varchar(30) NOT NULL,
    Password varchar(255) NOT NULL,
    Salt varchar(255) NOT NULL,
    TimestampCreated timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    PRIMARY KEY (UUID),
    CONSTRAINT account_email_unique UNIQUE (Email),
    CONSTRAINT account_email_length CHECK (length(Email) > 0 AND length(Email) <= 128),
    CONSTRAINT account_name_length CHECK (length(Name) > 0 AND length(Name) <= 30),
    CONSTRAINT account_password_length CHECK (length(Name) > 0 AND length(Name) <= 255),
    CONSTRAINT account_salt_length CHECK (length(Name) > 0 AND length(Name) <= 255)
);