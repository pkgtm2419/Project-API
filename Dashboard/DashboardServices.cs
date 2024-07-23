using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectAPI.masters.customer;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.Dashboard
{
    public class DashboardServices: IDashboard
    {
        private readonly ICustomer _customerServices;

        public DashboardServices(ICustomer CustomerServices)
        {
            _customerServices = CustomerServices;
        }

        public async Task<ResDashboardCustomer> GetDashboardDetails()
        {
            ResDashboardCustomer res = new ResDashboardCustomer();
            try
            {
                var result = await _customerServices.DashboardCustomerDetails();
                res.status = result.status;
                res.message = result.message;
                CustomerDashboardData data = new CustomerDashboardData();
                // data.CustomerSegment = result.data;
                List<CustomerDashboardData> dashboardList = new List<CustomerDashboardData>
                {
                    data
                };
                res.data = dashboardList;
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
