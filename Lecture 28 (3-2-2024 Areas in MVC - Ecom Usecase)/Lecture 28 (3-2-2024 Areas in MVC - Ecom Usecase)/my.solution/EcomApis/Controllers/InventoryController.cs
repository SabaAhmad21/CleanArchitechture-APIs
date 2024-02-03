using Microsoft.AspNetCore.Mvc;

namespace EcomApis.Controllers
{
    [ApiController]
    [Route("api/Inventory")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        [Route("CategoriesGetAll")]
        public IActionResult CategoriesGetAll()
        {
            return NotFound();
        }
    }
}
