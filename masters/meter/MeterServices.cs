﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Meter
{
    public class MeterServices : IMeter
    {
        private readonly IMongoCollection<MeterModel> _mst_meters;

        public MeterServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _mst_meters = database.GetCollection<MeterModel>(settings.Value.mst_meter);
        }

        public async Task<MeterRes> GetMetersAsync()
        {
            MeterRes res = new MeterRes();
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Empty;
                List<MeterModel> data = await _mst_meters.Find(filter).ToListAsync();
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

        public async Task<MeterRes> GetMetersByMeterIDAsync(int meterID)
        {
            MeterRes res = new MeterRes();
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("MeterID", meterID);
                List<MeterModel> data = await _mst_meters.Find(filter).ToListAsync();
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

        public async Task<bool> MeterExistsAsync(string meterID)
        {
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("meterID", meterID);
                List<MeterModel> data = await _mst_meters.Find(filter).ToListAsync();
                return data.Count > 0;
            } 
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
