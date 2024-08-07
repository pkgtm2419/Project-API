﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Counter
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController(ICounter counterService) : ControllerBase
    {
        private readonly ICounter _counterService = counterService;

        [HttpGet]
        public async Task<ActionResult<CounterRes>> GetCounter([FromHeader] string company)
        {
            var user = HttpContext.Items["User"] as JWTModel;
            if (user == null)
            {
                return Unauthorized(new { status = 401, message = "Invalid token" });
            }
            if(user.CompanyID != company)
            {
                return Unauthorized(new { status = 401, message = "User does not belong to this data." });
            }
            var res = await _counterService.GetCounterAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
