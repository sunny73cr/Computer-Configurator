# The Computer Configurator Database

This project contains the scripts for setting up the Computer Configurator database.
These SQL scripts are intended for use with PostgreSQL 14.

NOTES:
For Windows CMD You can clear the console using `\! cls`
Powershell is similar, using: ` \! clear `

You cannot drop the database that have open connections.
Close pgAdmin, and ensure nobody else is using the database before dropping it.
You can edit the cc_drop.sql script and append 'FORCE' in dire circumstances.
To do this, I connect to another database, like the 'postgres' db that the PostgreSQL installer creates.

To start with a 'clean slate' (TL;DR at the bottom.):

---

1. start the psql CLI.

   This binary is found in your PostgeSQL 14 installation folder;
   Mine is located at C:\Program Files\PostgreSQL\14\bin\psql.exe.

   For me, the command to navigate to the folder is:
   `cd C:\Program Files\PostgreSQL\14\bin\`

   Adjust your path accordingly.

---

2. connecting to the PostgresSQL server from the psql shell.

   `psql -d postgres`,
   or,
   `psql --dbname=dbname`
   Here, `-d` or `--dbname` indicates the database to connect to.

   You may also specify a hostname (ip address) and port, using:

   `-h hostname`
   or,
   `--host=hostname`

   in combination with;

   `-p port`
   or,
   `--port=port`

   To connect to a remote PostgreSQL server.

   The final command will look like:

   `psql -d postgres -h xxxx.xxxx.xxxx.xxxx -p yyyy`
   or,
   `psql --dbname=postgres --host=xxxx.xxxx.xxxx.xxxx --port=yyyy`

---

Steps 3 and 4 wipe an existing presence of the cc database.
You can skip to step 4 if you have not followed these steps before.
Ensure you are connected to the cc database before continuing with step 3.

---

3. purge (drop) the existing tables using the file `cc_purgetables.sql`

   The \i command for psql 'includes' a file and runs the script it contains.
   To run a script from another folder, specify the file path.
   If your path contains spaces, wrap it in single quotes:

   ` \i '{filepath}' `

   For me, this command is:

   `\i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_purgetables.sql' `

   Adjust your path accordingly.

   When using backslashes ` \ `, I encountered Permission errors.
   Using forward slashes ` / ` fixed it for me.

---

Ensure you are connected to a different database before continuing with step 4.
I use the postgres database. You may refer to step 2 if needed.

---

4. drop the existing database using the file ` cc_drop.sql `

   For me, this command is:

   ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_drop.sql' `

   Adjust your path accordingly.

---

5. create the database using the file ` cc_create.sql `

   For me, the command is:

   ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_create.sql' `

   Adjust your path accordingly.

---

Ensure you are connected to the cc database before continuing with step 6.
You may refer to step 2 if needed.

---

6. generate the schema using the file ` cc_ddl.sql `

   For me, the command is:

   ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_ddl.sql' `

   Adjust your path accordingly.

-----------------------------------------------------------------------------------------------------

TL;DR

1. cd C:\Program Files\PostgreSQL\14\bin\
2. psql -d postgres

Have you followed these steps before?

2b. ` \q `
2c. ` psql -d cc `
2d. ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_purgetables.sql' `
2e. ` \q `
2f. ` psql -d postgres `
2g. ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_drop.sql' `

Otherwise,

3. ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_create.sql' `
4. ` psql -d cc `
5. ` \i 'C:/Users/{UserName}/Desktop/Computer Configurator/computer-configurator-db/cc_ddl.sql' `
6. ` \q `

---

The database is now ready for use.
