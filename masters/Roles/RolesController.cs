using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Roles
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleControllers(IRoles role) : ControllerBase
    {
        private readonly IRoles _role = role;

        public JWTModel? GetUser()
        {
            return HttpContext.Items["User"] as JWTModel;
        }

        [HttpGet]
        public async Task<ActionResult<ResRoleMenu>> GetRoles([FromHeader] string companyID, JWTModel? User)
        {
            var res = await _role.GetRole(companyID);
            return res.Status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
