using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.Database
{
    public static class DatabaseService
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("dbConnection").GetValue<string>("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "MongoDB connection string cannot be null or empty.");
            }

            var client = new MongoClient(connectionString);
            services.AddSingleton<IMongoClient>(client);

            var databaseName = configuration.GetSection("dbConnection").GetValue<string>("DataBaseName");
            if (string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException(nameof(databaseName), "MongoDB database name cannot be null or empty.");
            }

            services.AddScoped<IMongoDatabase>(provider =>
            {
                var mongoClient = provider.GetRequiredService<IMongoClient>();
                return mongoClient.GetDatabase(databaseName);
            });
        }
    }
}
