using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItem ItemServices) : ControllerBase
    {
        private readonly IItem _itemsServices = ItemServices;

        [HttpGet]
        public async Task<ActionResult<ResItems>> GetItemsAsync()
        {
            var res = await _itemsServices.GetItemsAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }
    }
}
