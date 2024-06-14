using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.masters.counter
{
    public class CounterServices : CounterInterface
    {
        private readonly IMongoCollection<CounterModel> _counter;

        public CounterServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _counter = database.GetCollection<CounterModel>(settings.Value.counter);
        }

        public async Task<CounterRes> GetCounterAsync()
        {
            CounterRes res = new CounterRes();
            try
            {
                FilterDefinition<CounterModel> filter = Builders<CounterModel>.Filter.Empty;
                List<CounterModel> data = await _counter.Find(filter).ToListAsync();

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
                res.message = $"something went wrong: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
            return res;
        }
    }
}