using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;
using WinDLMSClientApp.Masters.Meter;

namespace WinDLMSClientApp.MeterConnection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeterConnectionController(IMeterConnection MeterConnectionServices, IMeter MeterMasterServices) : ControllerBase
    {
        private readonly IMeterConnection _MeterConnectionServices = MeterConnectionServices;
        private readonly IMeter _MeterMasterServices = MeterMasterServices;

        [HttpPost("GetAssociationData")]
        public async Task<IActionResult> GetAssociationData([FromBody] ReqGetMeterData body)
        {
            var isMeterExist = await _MeterMasterServices.MeterExistsAsync(body.meterID.ToString());
            if (!isMeterExist)
            {
                return BadRequest(new ResStatus
                {
                    status = 400,
                    message = "Meter doesn't exist"
                });
            }
            var res = await _MeterConnectionServices.GetAssociationData(body);
            return Ok();
        }
    }
}
