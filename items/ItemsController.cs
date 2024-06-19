using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.items
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController(IItems itemsServices) : ControllerBase
    {
        private readonly IItems _itemsServices = itemsServices;

        [HttpGet]
        public async Task<ActionResult<ResItems>> GetItems()
        {
            var res = await _itemsServices.GetItems();
            return res.status switch
                {
                    200 => Ok(res),
                    404 => NotFound(res),
                    _ => StatusCode(500, res)
                };
        }
    }
}