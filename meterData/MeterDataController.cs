using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.meterData
{
    [Route("api/[controller]")]
    [ApiController]

    public class MeterDataController(IMeterData _MeterDataInterface) : ControllerBase
    {
        private readonly IMeterData MeterDataInterface = _MeterDataInterface;

        [HttpGet("{meterID}")]
        public async Task<ActionResult<ResMeterData>> GetMeterData(string meterID)
        {
            if (await MeterExist(meterID))
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

        public async Task<bool> MeterExist(string meterID)
        {
            return await MeterDataInterface.MeterExist(meterID);
        }
    }
}