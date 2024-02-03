using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<CategoryVM>> CategoriesGetAll();
        Task<bool> CategoryCreate(CategoryCreateVM model);
        Task<bool> CategoryUpdate(CategoryUpdateVM model);
        Task<bool> CategoryDelete(int id);
    }
}
