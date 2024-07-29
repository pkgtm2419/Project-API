using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.LogicalName
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OBISCodeController(IOBISCode Interface) : ControllerBase
    {
        private readonly IOBISCode _OBISCodeInterface = Interface;

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
