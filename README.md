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