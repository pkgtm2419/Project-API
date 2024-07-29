using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Customer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomer customer) : ControllerBase
    {
        private readonly ICustomer _customer = customer;

        [HttpGet]
        public async Task<ActionResult<ResCustomer>> GetCustomer()
        {
            var res = await _customer.GetCustomerAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
