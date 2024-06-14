using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.masters.meter
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController(MeterInterface meterService) : ControllerBase
    {
        private readonly MeterInterface _meterService = meterService;

        [HttpGet]
        public async Task<ActionResult<MeterRes>> GetMetersAsync()
        {
            var res = await _meterService.GetMetersAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
