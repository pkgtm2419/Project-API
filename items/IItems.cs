using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Items
{
    public interface IItems
    {
        Task<ResItems> GetItems();
    }
}
