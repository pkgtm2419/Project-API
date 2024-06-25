using ProjectAPI.SchemaModel;

namespace ProjectAPI.meterData
{
    public interface IMeterData
    {
        Task<ResMeterData> GetMeterData(string meterID);
        Task<List<MeterModel>> MeterExist(string meterID);
    }
}
