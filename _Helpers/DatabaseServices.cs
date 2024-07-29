using MongoDB.Driver;

namespace WinDLMSClientApp._Helpers
{
    public static class DatabaseServices
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
