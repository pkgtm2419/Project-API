using Microsoft.AspNetCore.Mvc;
using ProjectAPI.masters.counter;
using ProjectAPI.SchemaModel;
using System;
using System.Threading.Tasks;

namespace ProjectAPI.masters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController(CounterInterface counterService) : ControllerBase
    {
        private readonly CounterInterface _counterService = counterService;

        [HttpGet]
        public async Task<ActionResult<CounterRes>> GetCounter()
        {
            var res = await _counterService.GetCounterAsync();
            return res.status == 200 ? Ok(res) :
                   res.status == 404 ? NotFound(res) :
                   StatusCode(500, res);
        }
    }
}
