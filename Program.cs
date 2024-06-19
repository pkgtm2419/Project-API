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
using Microsoft.AspNetCore.Diagnostics;
using ProjectAPI.meterData;
using ProjectAPI._Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.Configure<MongoDBSettingsModel>(builder.Configuration.GetSection("dbConnection"));

builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddScoped<IMeter, MeterServices>();
builder.Services.AddScoped<IOBISCode, OBISCodeServices>();
builder.Services.AddScoped<ICounter, CounterServices>();
builder.Services.AddScoped<IItems, ItemsServices>();
builder.Services.AddScoped<IMeterData, MeterDataServices>();

var app = builder.Build();
app.UseCompanyHeaderMiddleware();

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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error != null)
        {
            var errorResponse = new
            {
                status = 500,
                message = "An unexpected error occurred. Please try again later.",
                detail = exceptionHandlerPathFeature.Error.Message
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    });
});

app.UseStatusCodePages(context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.ContentType = "application/json";

        var errorResponse = new
        {
            status = 404,
            message = "The requested resource was not found."
        };

        return context.HttpContext.Response.WriteAsJsonAsync(errorResponse);
    }

    return Task.CompletedTask;
});

app.MapControllers();

app.Run();

public static class CompanyHeaderMiddlewareExtensions
{
    public static IApplicationBuilder UseCompanyHeaderMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeaderMiddleware>();
    }
}
