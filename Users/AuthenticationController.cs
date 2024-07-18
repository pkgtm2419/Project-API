using System.Text;
using ProjectAPI.SchemaModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjectAPI.UserAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthentication authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResUser>> GetAuthenticationUser([FromBody] ReqAuthentication body, [FromHeader] string company)
        {
            if (body == null || string.IsNullOrEmpty(body.username) || string.IsNullOrEmpty(body.password))
            {
                var resError = new ResUser
                {
                    status = 400,
                    message = "Invalid request. Username and password are required."
                };
                return BadRequest(resError);
            }
            var res = await _authenticationService.GetAuthentication(body.username, body.password, company);
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResUser>> CreateUser([FromBody] UsersModel body, [FromHeader] string company)
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
