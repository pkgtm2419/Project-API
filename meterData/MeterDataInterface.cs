using ProjectAPI.SchemaModel;

namespace ProjectAPI.meterData
{
    public interface MeterDataInterface
    {
        Task<ResMeterData> GetMeterData(string meterID);
        Task<bool> MeterExist(string meterID);
    }
}
