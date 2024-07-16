using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.customer
{
    public interface ICustomer
    {
        Task<ResCustomer> GetCustomerAsync();
    }
}
