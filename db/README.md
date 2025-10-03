## Database

The database schema is described in `skeema/` and is applied using [skeema](https://www.skeema.io/).

Open Dental uses a MariaDB database. As of writing, the latest version supported is 10.5;
however, I want to get that version increased to the latest versions.

There is a file `skeema/.skeema.SAMPLE` which you should copy to `skeema/.skeema`, then edit
the hostname/database name/user as needed.

See [skeema's docs](https://www.skeema.io/docs/examples/) for further information on editing the schema.

### Seed data

The Open Dental database has to be seeded with some amount of data to get it to start.
That data is in `minimum-data.sql`, which can be applied like you would an export from `mysqldump`,
after creating the tables using skeema.

### Note regarding insurance claim codes

The seed data will never include CDT dental codes, which are copyrighted by the American
Dental Association, for some reason.

You are welcome to obtain them through some other means and import them yourself.
Many dental insurance companies openly publish the codes on their websites for the benefit of providers
submitting claims.
