using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Customer
{
    public interface ICustomer
    {
        Task<ResCustomer> GetCustomerAsync();
        Task<ResDashboardCustomer> DashboardCustomerDetails();
    }
}
