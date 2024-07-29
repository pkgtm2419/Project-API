using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.LogicalName
{
    public interface IOBISCode
    {
        Task<ResOBISCodeList> GetOBISCodeAsync();
    }
}
