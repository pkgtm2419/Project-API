using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.customer
{
    public class CustomerServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : ICustomer
    {
        private readonly IMongoCollection<CustomerModel> _customer = database.GetCollection<CustomerModel>(settings.Value.mst_customer);

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
