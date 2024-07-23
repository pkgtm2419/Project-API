using ProjectAPI.SchemaModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLMS_CLIENT;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProjectAPI.meterData.GetMeterData
{
    public class GetMeterDataServices : IGetMeterData
    {
        private readonly IMongoCollection<MeterModel> _MeterMaster;
        private readonly IMongoDatabase _database;
        private readonly IOptions<MongoDBSettingsModel> _settings;

        public GetMeterDataServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _database = database;
            _settings = settings;
            _MeterMaster = database.GetCollection<MeterModel>(settings.Value.mst_meter);
        }

        public async Task<string> GetAssociationData(ReqGetMeterData body, List<MeterModel> MeterDetails)
        {
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("meterID", body.meterID);
                List<MeterModel> data = await _MeterMaster.Find(filter).ToListAsync();
                string result = $"Hello {body.meterID} : {body.association}";
                Console.WriteLine(result);
                Console.WriteLine("Count " + MeterDetails.Count);

                Poll_illustartion pollIllustrationInstance = new Poll_illustartion(_database, _settings);
                await pollIllustrationInstance.PollIllustration(MeterDetails[0], body.association ?? 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "Hello";
        }
    }
}
