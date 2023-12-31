# Initial

* Create Project 
```shell
dotnet new webapi -n netangularlogin  
```

* Add Reference 
```shell
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 7.0.0
dotnet add package Microsoft.AspNetCore.Identity -v 7.0.0
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 7.0.0
```

* Create Library or Create Folder
  - Create Core layer
  - Create DTO layer
  - Create Infrastructure layer
  - Create Extensions layer
Note: In case, Create Library (DLL) use command
```shell
dotnet new classlib -n Core
dotnet new classlib -n DTO
dotnet new classlib -n Infrastructure
dotnet new classlib -n Extensions
```



# EF 
* Install Commmand First
Ref: https://stackoverflow.com/questions/57066856/command-dotnet-ef-not-found
```shell
dotnet tool install --global dotnet-ef
```

* Add Reference for Dotnet EF Command
```shell
dotnet add package Microsoft.EntityFrameworkCore.Design -v 7.0.0
```
* Create Migration EF - After Run this command, you will see Migrations folder
Ref: https://stackoverflow.com/questions/55123853/unable-to-create-an-object-of-type-dbcontexts-name-for-the-different-patte
```shell
##- At Solution Folder 
dotnet ef migrations add InitialCreate --startup-project $pwd/netangularlogin  --verbose
##- At Project Folder 
dotnet ef migrations add initialcreate 
#Update Database
dotnet ef database update
#you will see database file identity.db at netangularlogin folder
```

* ERROR
  - SQLite Error 1: 'no such table: __EFMigrationsHistory'."
    - https://stackoverflow.com/questions/73508902/entity-framework-sqlite-error-1-no-such-table-efmigrationshistory
    - https://github.com/dotnet/efcore/issues/9842


#Create Controller Complete
- Create Controller

#How to Run
Note: In dotnet 7 add -lp --launch-profile 
```shell
dotnet run --launch-profile https
```
if you see this error 
```shell
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
```
Fix it by  https://learn.microsoft.com/en-us/answers/questions/1297509/how-to-fix-this-error-warn-microsoft-aspnetcore-ht
but it is feature https://github.com/dotnet/aspnetcore/issues/44722#issuecomment-1290621757

# Test URL
https://localhost:7060/swagger/index.html

Note: localhost:7060 >> From launchSettings.json profile https
