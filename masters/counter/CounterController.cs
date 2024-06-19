using Microsoft.AspNetCore.Mvc;
using ProjectAPI.masters.counter;
using ProjectAPI.SchemaModel;
using System;
using System.Threading.Tasks;

namespace ProjectAPI.masters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController(ICounter counterService) : ControllerBase
    {
        private readonly ICounter _counterService = counterService;

        [HttpGet]
        public async Task<ActionResult<CounterRes>> GetCounter()
        {
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
