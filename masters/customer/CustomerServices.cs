using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Customer
{
    public class CustomerServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : ICustomer
    {
        private readonly IMongoCollection<CustomerModel> _customer = database.GetCollection<CustomerModel>(settings.Value.mst_customer);

        public async Task<ResDashboardCustomer> DashboardCustomerDetails()
        {
            ResDashboardCustomer res = new ResDashboardCustomer();
            try
            {
                var currentDate = DateTime.UtcNow;
                var startOfYear = new DateTime(currentDate.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                var endOfYear = new DateTime(currentDate.Year, 12, 31, 23, 59, 59, DateTimeKind.Utc).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                var filterBuilder = Builders<CustomerModel>.Filter;
                var filter = filterBuilder.And(
                    filterBuilder.Gte(c => c.CreatedAt, startOfYear),
                    filterBuilder.Lte(c => c.CreatedAt, endOfYear),
                    filterBuilder.Gte(c => c.Stage, 4)
                );

                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$match", filter.ToBsonDocument()),
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", "$CustomerCategory" },
                        { "count", new BsonDocument("$sum", 1) }
                    })
                };

                var aggregation = await _customer.Aggregate<BsonDocument>(pipeline).ToListAsync();

                var result = new[] { "Residential", "Commercial", "Industrial" }
                    .Select(category => new
                    {
                        _id = category,
                        Count = aggregation.FirstOrDefault(a => a["_id"].AsString == category)?["count"].AsInt32 ?? 0
                    });
                res.status = result.Count() > 0 ? 200 : 404;
                // res.data = result;
                res.message = "success";
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = ex.Message;
                Console.WriteLine(ex.StackTrace);
            }
            return res;
        }

        public async Task<ResCustomer> GetCustomerAsync()
        {
            ResCustomer res = new ResCustomer();
            try
            {
                FilterDefinition<CustomerModel> filter = Builders<CustomerModel>.Filter.Empty;
                List<CustomerModel> data = await _customer.Find(filter).ToListAsync();
                if (data.Count > 0)
                {
                    res.status = 200;
                    res.data = data;
                    res.message = "success";
                }
                else
                {
                    res.status = 404;
                    res.message = "no data found";
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = ex.Message;
                Console.WriteLine(ex.StackTrace);
            }
            return res;
        }
    }
}
