using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.masters.meter
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController(IMeter meterService) : ControllerBase
    {
        private readonly IMeter _meterService = meterService;

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

        [HttpGet("{meterID}")]
        public async Task<ActionResult<MeterRes>> GetMetersByMeterIDAsync(int meterID)
        {
            var res = await _meterService.GetMetersByMeterIDAsync(meterID);
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
