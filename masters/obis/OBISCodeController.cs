using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.masters.meter;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.obis
{
    [Route("api/[controller]")]
    [ApiController]
    public class OBISCodeController(OBISCodeInterface Interface) : ControllerBase
    {
        private readonly OBISCodeInterface _OBISCodeInterface = Interface;

        [HttpGet]
        public async Task<ActionResult<ResOBISCodeList>> GetOBISCodeAsync()
        {
            var res = await _OBISCodeInterface.GetOBISCodeAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
