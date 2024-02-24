# Backend Database Migrations

Information about Entity Framework can be found here: [https://learn.microsoft.com/en-us/ef/core/](https://learn.microsoft.com/en-us/ef/core/)

## Pre-requisites
Make sure you download the `dotnet ef` tool as per the documentation linked above

Add the following to your `appsettings.Development.json` file (you can look in appsettings.json for template as well) and make sure to update with the correct host and other information for your local instance.

```
"ConnectionStrings": {
    "Postgres": "Host=127.0.0.1;Username=postgres;Password=example;Database=whatthehealth;sslmode=disable"
}
```

## Adding a migration after updating entities

Open a terminal to the `WhatTheHealth.API` folder and execute the following command:

`dotnet ef migrations add {MigrationName} --project ..\WhatTheHealth.Infrastructure`

Make sure to switch out `{MigrationName}` for the name you want your migration to have.

### Updating the database with new migrations

Open a terminal to the `WhatTheHealth.API` folder and execute the following command:

`dotnet ef database update`

### Getting the SQL for updating the remote DB
`dotnet ef migrations script {FromMigrationName} --project ../WhatTheHealth.Infrastructure/WhatTheHealth.Infrastructure.csproj`