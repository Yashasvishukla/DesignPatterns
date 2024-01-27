

using Infra.Dish;
using Infra.LegoModels;
using Infra.VideoGameManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
 *
 * Here we have two different contexts
 * command to do the migrations for a specific context is as follows
 * dotnet ef migrations add [Migration Name] -p [Project] -c [DbContext]
 * eg. dotnet ef migrations add InitialMigration -p ../Infra -c BrickContext
 *
 *
 * command to update the migrations and table creation goes as follow
 * dotnet ef database update -c [Context]
 * eg. dotnet ef database update -c BrickContext
 */

builder.Services.AddDbContext<VideoGameDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<BrickContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BrickConnection")));

builder.Services.AddDbContext<CookbookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CookbookConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
