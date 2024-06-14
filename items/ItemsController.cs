using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.items
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController(ItemsInterface itemsServices) : ControllerBase
    {
        private readonly ItemsInterface _itemsServices = itemsServices;

        [HttpGet]
        public async Task<ActionResult<ResItems>> GetItems()
        {
            var res = await _itemsServices.GetItems();
            return res.status == 200 ? Ok(res) :
                   res.status == 404 ? NotFound(res) :
                   StatusCode(500, res);
        }
    }
}