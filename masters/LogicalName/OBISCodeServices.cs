using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.LogicalName
{
    public class OBISCodeServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IOBISCode
    {
        private readonly IMongoCollection<OBISCodeModel> _mst_obis = database.GetCollection<OBISCodeModel>(settings.Value.mst_obis);

        public async Task<ResOBISCodeList> GetOBISCodeAsync()
        {
            ResOBISCodeList res = new ResOBISCodeList();
            try
            {
                FilterDefinition<OBISCodeModel> filter = Builders<OBISCodeModel>.Filter.Empty;
                List<OBISCodeModel> data = await _mst_obis.Find(filter).ToListAsync();
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
