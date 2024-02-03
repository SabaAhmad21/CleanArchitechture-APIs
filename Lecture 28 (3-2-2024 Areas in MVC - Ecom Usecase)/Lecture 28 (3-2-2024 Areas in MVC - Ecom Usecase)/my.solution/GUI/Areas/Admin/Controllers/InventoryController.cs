using Infrastructure.Implementation;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IActionResult> Categories()
        {
            return View(await _inventoryRepository.CategoriesGetAll());
        }
    }
}
