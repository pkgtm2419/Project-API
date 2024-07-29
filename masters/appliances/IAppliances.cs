using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Appliances
{
    public interface IAppliances
    {
        Task<ResAppliances> GetAppliances();
    }
}
