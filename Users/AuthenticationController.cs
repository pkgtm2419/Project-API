using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectAPI.SchemaModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task<ActionResult<ResUser>> GetAuthenticationUser([FromBody] ReqAuthentication body)
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
            var res = await _authenticationService.GetAuthentication(body.username, body.password);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("username", body.username.ToString()),
                new Claim("email", res.data[0].Email),
                new Claim("role", res.data[0].Role),
                new Claim("companyID", res.data[0].CompanyID)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(7), signingCredentials: signIn);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            res.token = tokenValue;
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
