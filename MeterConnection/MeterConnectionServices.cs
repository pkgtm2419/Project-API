using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.MeterConnection
{
    public class MeterConnectionServices: IMeterConnection
    {
        private readonly IMongoCollection<MeterModel> _MeterMaster;
        private readonly IMongoCollection<OBISCodeModel> _mst_obis;

        public MeterConnectionServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _MeterMaster = database.GetCollection<MeterModel>(settings.Value.mst_meter);
            _mst_obis = database.GetCollection<OBISCodeModel>(settings.Value.mst_obis);
        }

        public async Task<string> GetAssociationData(ReqGetMeterData body)
        {
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("meterID", body.meterID);
                List<MeterModel> data = await _MeterMaster.Find(filter).ToListAsync();
                return data.Count > 0 ? "success" : "no data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
