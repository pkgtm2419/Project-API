using ProjectAPI;
using ProjectAPI.Database;
using ProjectAPI.SchemaModel;
using ProjectAPI.masters.obis;
using ProjectAPI.masters.meter;
using ProjectAPI.masters.counter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectAPI.items;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.Configure<MongoDBSettingsModel>(builder.Configuration.GetSection("dbConnection"));

builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddScoped<MeterInterface, MeterServices>();
builder.Services.AddScoped<OBISCodeInterface, OBISCodeServices>();
builder.Services.AddScoped<CounterInterface, CounterServices>();
builder.Services.AddScoped<ItemsInterface, ItemsServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () =>
    {
        return new ResStatus
        {
            status = true,
            message = "Welcome to the landing page!"
        };
    });
}

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
