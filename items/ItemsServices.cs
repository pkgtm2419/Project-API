using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.items
{
    public class ItemsServices : IItems
    {
        private readonly IMongoCollection<ItemsModel> _items;

        public ItemsServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _items = database.GetCollection<ItemsModel>(settings.Value.items);
        }

        public async Task<ResItems> GetItems()
        {
            ResItems res = new ResItems();
            try
            {
                FilterDefinition<ItemsModel> filter = Builders<ItemsModel>.Filter.Empty;
                List<ItemsModel> data = await _items.Find(filter).ToListAsync();
                if(data.Count > 0)
                {
                    res.status = 200;
                    res.data = data;
                    res.message = "Success";
                } else
                {
                    res.status = 404;
                    res.message = "Not Found";
                }
            } catch (Exception ex) {
                res.status = 500;
                res.message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
}
