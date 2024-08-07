using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Company
{
    [Authorize]
    [Route("master/[controller]")]
    [ApiController]
    public class CompanyController(ICompany companyServices) : ControllerBase
    {
        private readonly ICompany _companyServices = companyServices;

        [HttpGet("getCompany")]
        public async Task<ActionResult<ResCompany>> getCompany()
        {
            var res = await _companyServices.GetCompanyAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
