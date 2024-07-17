using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.meterData
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeterDataController(IMeterData _MeterDataInterface) : ControllerBase
    {
        private readonly IMeterData MeterDataInterface = _MeterDataInterface;

        [HttpGet("{meterID}")]
        public async Task<ActionResult<ResMeterData>> GetMeterData(string meterID)
        {
            var meter = await MeterExist(meterID);
            if (meter.Count > 0)
            {

                var res = await MeterDataInterface.GetMeterData(meterID);
                return res.status switch
                {
                    200 => Ok(res),
                    404 => NotFound(res),
                    _ => StatusCode(500, res)
                };
            } else
            {
                return NotFound(new ResMeterData
                {
                    status = 404,
                    message = "Meter is not exist"
                });
            }
        }

        public async Task<List<MeterModel>> MeterExist(string meterID)
        {
            Console.WriteLine(meterID);
            return await MeterDataInterface.MeterExist(meterID);
        }
    }
}