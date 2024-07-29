using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Appliances
{
    public class AppliancesServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IAppliances
    {
        private readonly IMongoCollection<AppliancesModel> _appliances = database.GetCollection<AppliancesModel>(settings.Value.mst_appliances);

        public async Task<ResAppliances> GetAppliances()
        {
            ResAppliances res = new ResAppliances();
            try
            {
                FilterDefinition<AppliancesModel> filter = Builders<AppliancesModel>.Filter.Empty;
                List<AppliancesModel> data = await _appliances.Find(filter).ToListAsync();
                res.status = data.Count > 0 ? 200 : 404;
                res.data = data;
                res.message = res.status == 200 ? "Success" : "Not Found";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res.status = 500;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
