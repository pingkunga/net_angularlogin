using netangularlogin.Core.Entities;
using netangularlogin.Extensions;
using netangularlogin.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Call Extension Method ลืมแล้วจะ Error
//Unable to create an object of type 'AppIdentityDbContext'
//. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728      

//see https://go.microsoft.com/fwlink/?linkid=851728
//---> System.InvalidOperationException: Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions`1[netangularlogin.Infrastructure.Data.AppIdentityDbContext]' while attempting to activate 'netangularlogin.Infrastructure.Data.AppIdentityDbContext'.
//   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.ConstructorMatcher.CreateInstance(IServiceProvider provider)
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
