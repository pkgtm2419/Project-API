using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.item
{
    public class ItemServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IItem
    {
        private readonly IMongoCollection<ItemsModel> _item = database.GetCollection<ItemsModel>(settings.Value.items);

        public async Task<ResItems> GetItemsAsync()
        {
            ResItems res = new ResItems();
            try
            {
                FilterDefinition<ItemsModel> filter = Builders<ItemsModel>.Filter.Empty;
                List<ItemsModel> data = await _item.Find(filter).ToListAsync();
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
            }
            return res;
        }
    }
}
