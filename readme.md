	
dotnet new webapi -n netangularlogin  

#Reference 
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 7.0.0
dotnet add package Microsoft.AspNetCore.Identity -v 7.0.0
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 7.0.0



#Create Library or Create Folder
- Create Core layer
dotnet new classlib -n Core
- Create DTO layer
dotnet new classlib -n DTO
- Create Infrastructure layer
dotnet new classlib -n Infrastructure
- Create Extensions layer
dotnet new classlib -n Extensions


#Install Commmand First
//https://stackoverflow.com/questions/57066856/command-dotnet-ef-not-found
dotnet tool install --global dotnet-ef

#For Dotnet EF Command
dotnet add package Microsoft.EntityFrameworkCore.Design -v 7.0.0

#Create Migration EF - After Run this command, you will see Migrations folder
--https://stackoverflow.com/questions/55123853/unable-to-create-an-object-of-type-dbcontexts-name-for-the-different-patte
##- At Solution Folder 
dotnet ef migrations add InitialCreate --startup-project $pwd/netangularlogin  --verbose
##- At Project Folder 
dotnet ef migrations add initialcreate 
#Update Database
dotnet ef database update
#you will see database file identity.db at netangularlogin folder

#ref
"SQLite Error 1: 'no such table: __EFMigrationsHistory'."
https://stackoverflow.com/questions/73508902/entity-framework-sqlite-error-1-no-such-table-efmigrationshistory
https://github.com/dotnet/efcore/issues/9842


#Create Controller Complete

#Run Test

dotnet run --launch-profile https

if you see this error 
'''
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
'''
Fix it by  https://learn.microsoft.com/en-us/answers/questions/1297509/how-to-fix-this-error-warn-microsoft-aspnetcore-ht
but it is feature https://github.com/dotnet/aspnetcore/issues/44722#issuecomment-1290621757

# Test URL
https://localhost:7060/swagger/index.html

# localhost:7060 >> From launchSettings.json profile https