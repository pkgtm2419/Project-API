using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.appliances
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliancesController(IAppliances appliances) : ControllerBase
    {
        private readonly IAppliances _appliances = appliances;

        [HttpGet]
        public async Task<ActionResult<ResAppliances>> GetAppliances()
        {
            var res = await _appliances.GetAppliances();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
