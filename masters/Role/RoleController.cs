using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.Role
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }

        public JWTModel? GetUser()
        {
            return HttpContext.Items["User"] as JWTModel;
        }

        [HttpGet]
        public async Task<ActionResult<ResRoleMenu>> GetRoles([FromHeader] string companyID, JWTModel? User)
        {
            var res = await _role.GetRole();
            return res.Status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
