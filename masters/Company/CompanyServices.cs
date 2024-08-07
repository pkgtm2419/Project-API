using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Company
{
    public class CompanyServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : ICompany
    {
        private readonly IMongoCollection<CompanyModel> _company = database.GetCollection<CompanyModel>(settings.Value.mst_company);

        public async Task<ResCompany> GetCompanyAsync()
        {
            ResCompany res = new ResCompany();
            try
            {
                FilterDefinition<CompanyModel> filter = Builders<CompanyModel>.Filter.Empty;
                List<CompanyModel> data = await _company.Find(filter).ToListAsync();
                res.status = data.Count > 0 ? 200 : 404;
                res.data = data;
                res.message = res.status == 200 ? "Success" : "Not Found";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                res.status = 500;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
