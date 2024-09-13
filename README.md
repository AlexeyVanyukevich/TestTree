## Migrations

To manage Entity Framework migrations, you can use the following commands:

### Create Migration

To create a new migration, use:

```bash
dotnet ef migrations add {migration_name} -p Tree.Persistence -s Tree.API
```

### Apply Migration

To apply the latest migration to the database, use:

```bash
dotnet ef database update -p Tree.Persistence -s Tree.API
```

### Remove Migration

To remove the most recent migration, use:

```bash
dotnet ef migrations remove -p Tree.Persistence -s Tree.API
```

## Project Configuration

### Database Configuration

This project uses PostgreSQL as the database. The configuration for connecting to the PostgreSQL database is specified in the `appsettings.json` file. Below are the key settings you need to configure:

#### Connection Strings

- **Application**: This setting defines the connection string used to connect to the PostgreSQL database. Update this connection string with your PostgreSQL server details.

  ```json
  "ConnectionStrings": {
    "Application": ""
  }
  ```

- **Host**: The hostname or IP address of your PostgreSQL server (e.g., `localhost` for local development).
- **Port**: The port number on which the PostgreSQL server is listening (default is `5432`).
- **Database**: The name of the database to connect to (e.g., `Tree`).
- **Username**: The username used to authenticate with the PostgreSQL server (e.g., `postgres`).
- **Password**: The password for the specified username.

### Database Timeout

- **Timeout**: This setting specifies the timeout duration (in seconds) for database operations. You can adjust this value based on your performance needs.

  ```json
  "Database": {
    "Timeout": 30
  }
  ```
