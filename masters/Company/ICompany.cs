using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Company
{
    public interface ICompany
    {
        Task<ResCompany> GetCompanyAsync();
    }
}
