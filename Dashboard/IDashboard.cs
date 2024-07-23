using ProjectAPI.SchemaModel;

namespace ProjectAPI.Dashboard
{
    public interface IDashboard
    {
        Task<ResDashboardCustomer> GetDashboardDetails();
    }
}
