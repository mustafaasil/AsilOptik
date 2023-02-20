# AsilOptik (E-Commerce)

A sample N-layerd .NET Core Project with Clean Architecture and the generic repository pattern 

## Migrations

### Infrastructure

Firstly, set the project "web" as startup project
secondly choose ýnfrastructure on package manager console

```
Add-Migration InitialCreate -context ShopContext -o Data/Migrations
Update-Database -context ShopContext
```


## Packages Installed

### Infrastructure
```
Install-Package Microsoft.EntityFrameworkCore -v 6.0.14
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.14
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 6.0.8
```

### ApplicationCore
```
Install-Package Ardalis.Specification -v 6.1.0
```

## Useful Links
### Documentation

https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/ 

### GitHub

https://github.com/dotnet-architecture/eShopOnWeb 

### E-book

https://aka.ms/webappebook