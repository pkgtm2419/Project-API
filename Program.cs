using System.Text;
using System.Text.Json;
using WinDLMSClientApp.Users;
using WinDLMSClientApp._Models;
using WinDLMSClientApp._Helpers;
using Microsoft.IdentityModel.Tokens;
using WinDLMSClientApp._Helpers.Hashing;
using WinDLMSClientApp._Helpers.JWT;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WinDLMSClientApp.Masters.Roles;
using System.Diagnostics.Metrics;
using WinDLMSClientApp.Dashboard;
using WinDLMSClientApp.Masters.Appliances;
using WinDLMSClientApp.Masters.Customer;
using WinDLMSClientApp.Masters.Counter;
using WinDLMSClientApp.Masters.LogicalName;
using WinDLMSClientApp.Masters.Meter;
using WinDLMSClientApp.Masters.Users;
using WinDLMSClientApp.Items;
using WinDLMSClientApp.MeterConnection;
using WinDLMSClientApp.Masters.Company;

namespace WinDLMSClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var JWTDetails = builder.Configuration.GetSection("Jwt");
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
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JWTDetails["Issuer"],
                    ValidAudience = JWTDetails["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTDetails.GetSection("Key").Value!))
                };

                opt.Events = new JwtBearerEvents
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
            builder.Services.AddScoped<IHashing, HashingServices>();
            builder.Services.AddScoped<IJWT, JWTServices>();
            builder.Services.AddScoped<IRoles, RolesServices>();
            builder.Services.AddScoped<IDashboard, DashboardServices>();
            builder.Services.AddScoped<IAppliances, AppliancesServices>();
            builder.Services.AddScoped<ICustomer, CustomerServices>();
            builder.Services.AddScoped<ICompany, CompanyServices>();
            builder.Services.AddScoped<IMeter, MeterServices>();
            builder.Services.AddScoped<IItems, ItemsServices>();
            builder.Services.AddScoped<IOBISCode, OBISCodeServices>();
            builder.Services.AddScoped<ICounter, CounterServices>();
            builder.Services.AddScoped<IUsers, UsersServices>();
            builder.Services.AddScoped<IMeterConnection, MeterConnectionServices> ();
            builder.Services.AddAuthorization();

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
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<JWTMiddleware>();
            app.UseCors("AllowAll");
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
            app.MapControllers();
            app.Run();
        }
    }
}