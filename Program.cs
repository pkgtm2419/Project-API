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
using ProjectAPI.masters.appliances;
using ProjectAPI.meterData.GetMeterData;
using ProjectAPI.masters.customer;
using ProjectAPI.masters.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.UserAuthentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.Configure<MongoDBSettingsModel>(builder.Configuration.GetSection("dbConnection"));

builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddScoped<IAuthentication, AuthenticationServices> ();
builder.Services.AddScoped<IMeter, MeterServices>();
builder.Services.AddScoped<IOBISCode, OBISCodeServices>();
builder.Services.AddScoped<ICounter, CounterServices>();
builder.Services.AddScoped<IMeterData, MeterDataServices>();
builder.Services.AddScoped<IAppliances, AppliancesServices>();
builder.Services.AddScoped<IGetMeterData, GetMeterDataServices>();
builder.Services.AddScoped<ICustomer, CustomerServices>();
builder.Services.AddScoped<IItems, ItemsServices> ();
builder.Services.AddScoped<IUsers, UsersServices> ();

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