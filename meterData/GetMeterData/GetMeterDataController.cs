using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.meterData.GetMeterData
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetMeterDataController(IGetMeterData getMeterDataInterface, IMeterData _MeterDataInterface) : ControllerBase
    {
        private readonly IGetMeterData _getMeterDataInterface = getMeterDataInterface;
        private readonly IMeterData MeterDataInterface = _MeterDataInterface;

        [HttpPost("GetAssociationData")]
        public async Task<IActionResult> GetAssociationData([FromBody] ReqGetMeterData body)
        {
            var meter = await MeterDataInterface.MeterExist(body.meterID.ToString());
            if (meter.Count == 0)
            {
                return BadRequest(new ResStatus
                {
                    status = 400,
                    message = "Meter doesn't exist"
                });
            }
            var data = await _getMeterDataInterface.GetAssociationData(body, meter);
            return Ok(data);
        }
    }
}
