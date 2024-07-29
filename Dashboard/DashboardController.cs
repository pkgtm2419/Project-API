using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Dashboard
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DashboardController(IDashboard DashboardServices) : ControllerBase
    {
        private readonly IDashboard _DashboardServices = DashboardServices;

        [HttpPost("getDashboardBills")]
        public async Task<ActionResult<ResStatus>> GetDashboardDetails()
        {
            var res = await _DashboardServices.GetDashboardDetails();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
