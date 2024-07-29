using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Meter
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
