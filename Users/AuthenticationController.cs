using System.Text;
using ProjectAPI.SchemaModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjectAPI.UserAuthentication
{
    [Route("users")]
    [ApiController]
    public class AuthenticationController(IAuthentication authenticationService, IConfiguration configuration) : ControllerBase
    {
        private readonly IAuthentication _authenticationService = authenticationService;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<ResUser>> GetAuthenticationUser([FromBody] ReqAuthentication body, [FromHeader] string companyID)
        {
            if (body == null || string.IsNullOrEmpty(body.loginName) || string.IsNullOrEmpty(body.password))
            {
                var resError = new ResUser
                {
                    status = 400,
                    message = "Invalid request. Username and password are required."
                };
                return BadRequest(resError);
            }
            var res = await _authenticationService.GetAuthentication(body.loginName, body.password, companyID);
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResUser>> CreateUser([FromForm] UsersModel body, [FromHeader] string company)
        {
            if (body == null || string.IsNullOrEmpty(body.LoginName) || string.IsNullOrEmpty(body.Password))
            {
                var resError = new ResUser
                {
                    status = 400,
                    message = "Invalid request. Username and password are required."
                };
                return BadRequest(resError);
            }
            body.CompanyID = company;
            var res = await _authenticationService.CreateUser(body);
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
