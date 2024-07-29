using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Dashboard
{
    public interface IDashboard
    {
        Task<ResDashboardCustomer> GetDashboardDetails();
    }
}
