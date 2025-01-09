using AdventureWorks.Services;
using AdventureWorks.Api.Configuration;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
