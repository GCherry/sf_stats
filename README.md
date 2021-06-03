# sf_stats

[![.NET](https://github.com/GCherry/sf_stats/actions/workflows/dotnet.yml/badge.svg)](https://github.com/GCherry/sf_stats/actions/workflows/dotnet.yml)

## Dev Setup

 

### Install Visual studio

[Download Visual Studio](https://visualstudio.microsoft.com/downloads/)

 

### Install SQL Server

[Download SQL Server Express](https://www.microsoft.com/en-us/download/details.aspx?id=101064) and install it. You will need admin privlages and TLS enabled.

 

### Install EF Core Tools

To enable the ability to migrate db changes via the command line, EF Core Tools needs to be installed. It is recommended to install the tool set globally.

 

To install the tools use the following command:

 

```

dotnet tool install --global dotnet-ef

```

 

To migrate the tools to the latest version use the following command:

 

```

dotnet tool update --global dotnet-ef

```

 

## How To Migrate Database Changes

You can update your database with the latest migrations using either _EF Core Tools_ or the _EF Core Design Tools_ nuget package. Under the hood, they are the same. EF Core Design Tools wrap EF Core Tools in powershell and at times it can be a bit more convienient to use them from within Visual Studio. Use whatever method you prefer.

 

### How To Migrate Database Changes using EF Core Tools

 

This project is using a [code-first](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0) approach for migrating data changes to the database (Microsoft SQL Server).

 

##### To migrate database changes to the latest version

 

```

dotnet ef database update --project csprojpath

```

 

_Note: This is a relative path from the root of the repository._

 

##### To revert a change or to update the database to a specific migration

 

```

dotnet ef database update <migration_name/migration_id> --project csprojpath

```

 

_Note: This is a relative path from the root of the repository._

 

_Note2: If a value of 0 is passed in as a parameter it will revert the database to an empty state._

 

### How To Migrate Database Changes using EF Core Design Tools (Powershell)

EF Core Design Tools is a nuget package that includes the EF Core Tools functionality in powershell commands. This is an easy way to generate and apply migrations from within visual studio itself. This method can be more convienent when working withing visual studio itself.

 

##### Open Package Manager Console

You can do this from the Package Manager Console which can be opened via _View > Other Windows > Package Manager Console_

 

##### Update Database

 

```

update-database

```

##### Update Database to a specific migration or rollback a migration:

```

update-database <migration_name>

```
