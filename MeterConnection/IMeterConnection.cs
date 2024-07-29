using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.MeterConnection
{
    public interface IMeterConnection
    {
        Task<string> GetAssociationData(ReqGetMeterData body);
    }
}
