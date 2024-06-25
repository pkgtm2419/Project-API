using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.meterData
{
    public class MeterDataServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IMeterData
    {
        private readonly IMongoCollection<MeterData> _MeterData = database.GetCollection<MeterData>(settings.Value.meter_data);
        private readonly IMongoCollection<MeterModel> _MeterMaster = database.GetCollection<MeterModel>(settings.Value.mst_meter);

        public async Task<ResMeterData> GetMeterData(string meterID)
        {
            ResMeterData res = new ResMeterData();
            try
            {
                FilterDefinition<MeterData> filter = Builders<MeterData>.Filter.Eq("meterID", meterID);
                List<MeterData> data = await _MeterData.Find(filter).ToListAsync();
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

        public async Task<List<MeterModel>> MeterExist(string meterID)
        {
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("meterID", meterID);
                List<MeterModel> data = await _MeterMaster.Find(filter).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MeterModel>();
            }
        }

    }
}
