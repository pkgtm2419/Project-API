using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Meter
{
    public interface IMeter
    {
        Task<MeterRes> GetMetersAsync();
        Task<MeterRes> GetMetersByMeterIDAsync(int meterID);
        Task<bool> MeterExistsAsync(string meterID);
    }
}
