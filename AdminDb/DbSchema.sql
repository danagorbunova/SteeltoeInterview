CREATE TABLE "Users" (
    "Id" SERIAl PRIMARY KEY,
    "FirstName" VARCHAR(100) NOT NULL,
    "LastName" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL
);

-- Initial data
INSERT INTO "Users" ("FirstName", "LastName", "Email") VALUES ('Steel', 'Knee', 'steelknee@sendmemail.net');
INSERT INTO "Users" ("FirstName", "LastName", "Email") VALUES ('Easter', 'Bunny', 'gotcarrots@carrotfoundry.io');
INSERT INTO "Users" ("FirstName", "LastName", "Email") VALUES ('Jane', 'Doe', 'janedoe@sendmemail.net');