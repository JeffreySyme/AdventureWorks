using AdventureWorks.Services;
using AdventureWorks.Api.Configuration;
using Microsoft.Extensions.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddAdventureWorksServices(config =>
{
    config.AddAdventureWorksDb(configuration.GetConnectionString("AdventureWorksDatabase"));
});

builder.Services
    .AddControllers()
    .AddOData();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOrigins = "_corsOrigins";

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(corsOrigins, policy => policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(corsOrigins);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
