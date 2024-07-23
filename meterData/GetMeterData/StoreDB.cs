using DLMS_CLIENT;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectAPI.SchemaModel;
using System;
using System.Threading.Tasks;

namespace ProjectAPI.meterData.GetMeterData
{
    public class StoreDB(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
    {
        private readonly IMongoCollection<BsonDocument> _MeterData = database.GetCollection<BsonDocument>(settings.Value.dlsmData);

        public async Task StoreInDB(DLMS_UNION_CS[] dlmsData, ushort[] classIDList, byte[] attrMethIdList, uint numDescriptors, byte version)
        {
            try
            {
                Console.WriteLine("Storing data...");
                DateTime utcDateTime = DateTime.UtcNow;
                TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, indianTimeZone);
                string timeStamp = indianDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");

                foreach (var data in dlmsData)
                {
                    var document = new BsonDocument
                    {
                        { "classIDList", new BsonArray(classIDList) },
                        { "attrMethIdList", new BsonArray(attrMethIdList) },
                        { "numDescriptors", numDescriptors },
                        { "version", version },
                        { "dlmsData", data.ToBsonDocument() },
                        { "createdDate", timeStamp }
                    };

                    await _MeterData.InsertOneAsync(document);
                }
                Console.WriteLine("Data stored in MongoDB successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}
