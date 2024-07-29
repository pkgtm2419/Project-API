using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsers users) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResUser>> GetUsers()
        {
            var res = await users.GetUserAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
