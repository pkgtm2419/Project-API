using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Authentication;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Users
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
                404 => NotFound(new ResUser
                {
                    status = 404,
                    message = res.message
                }),
                _ => StatusCode(500, new ResUser
                {
                    status = 500,
                    message = res.message
                })
            };
        }
    }
}
