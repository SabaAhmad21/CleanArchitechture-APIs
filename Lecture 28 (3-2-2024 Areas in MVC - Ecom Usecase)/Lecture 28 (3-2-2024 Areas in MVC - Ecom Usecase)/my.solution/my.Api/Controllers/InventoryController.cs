using Infrastructure.Implementation;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Infrastructure.ViewModels.ApisVM;
using Microsoft.AspNetCore.Mvc;

namespace my.Api.Controllers
{
    [ApiController]
    [Route("api/Inventory/")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        [HttpGet]
        [Route("CategoriesGetAll")]
        public async Task<ResponseModel> CategoriesGetAll()
        {
            return ResponseModel.Success(await _inventoryRepository.CategoriesGetAll(), "Categories");
        }
        [HttpPost]
        [Route("CategoryCreate")]
        public async Task<ResponseModel> CategoryCreate([FromBody]CategoryCreateVM model)
        {
            return ResponseModel.Created(await _inventoryRepository.CategoryCreate(model), "Category Created!");
        }
        [HttpPut]
        [Route("CategoryUpdate")]
        public async Task<ResponseModel> CategoryUpdate([FromBody] CategoryUpdateVM model)
        {
            return ResponseModel.Success(await _inventoryRepository.CategoryUpdate(model), "Category Updated!");
        }
        [HttpDelete]
        [Route("CategoryDelete")]
        public async Task<ResponseModel> CategoryDelete(int id)
        {
            return ResponseModel.Success(await _inventoryRepository.CategoryDelete(id), "Category Deleted!");
        }
    }
}
