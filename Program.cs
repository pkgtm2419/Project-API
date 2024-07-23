using ProjectAPI;
using System.Text;
using ProjectAPI.items;
using System.Text.Json;
using ProjectAPI.Database;
using ProjectAPI.meterData;
using ProjectAPI.SchemaModel;
using ProjectAPI.masters.obis;
using ProjectAPI._Helpers.JWT;
using ProjectAPI.masters.Users;
using ProjectAPI.masters.meter;
using ProjectAPI.masters.counter;
using ProjectAPI.masters.customer;
using ProjectAPI._Helpers.Hashing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using ProjectAPI.UserAuthentication;
using ProjectAPI.masters.appliances;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Diagnostics;
using ProjectAPI.meterData.GetMeterData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjectAPI.masters.Role;
using ProjectAPI.Dashboard;

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
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                status = 401,
                message = "You are not authorized to access this resource. Please try after logging in."
            });
            return context.Response.WriteAsync(result);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                status = 403,
                message = "You do not have permission to access this resource. Please contact your administrator."
            });
            return context.Response.WriteAsync(result);
        }
    };
});

builder.Services.Configure<MongoDBSettingsModel>(builder.Configuration.GetSection("dbConnection"));

builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddScoped<IAuthentication, AuthenticationServices>();
builder.Services.AddScoped<IDashboard, DashboardServices>();
builder.Services.AddScoped<IMeter, MeterServices>();
builder.Services.AddScoped<IOBISCode, OBISCodeServices>();
builder.Services.AddScoped<ICounter, CounterServices>();
builder.Services.AddScoped<IMeterData, MeterDataServices>();
builder.Services.AddScoped<IAppliances, AppliancesServices>();
builder.Services.AddScoped<IGetMeterData, GetMeterDataServices>();
builder.Services.AddScoped<ICustomer, CustomerServices>();
builder.Services.AddScoped<IItems, ItemsServices>();
builder.Services.AddScoped<IUsers, UsersServices>();
builder.Services.AddScoped<IHashing, HashingServices>();
builder.Services.AddScoped<IJwt, JwtServices>();
builder.Services.AddScoped<IRole, RoleServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () =>
    {
        return new ResStatus
        {
            status = 200,
            message = "Welcome to the landing page!"
        };
    });
}

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

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