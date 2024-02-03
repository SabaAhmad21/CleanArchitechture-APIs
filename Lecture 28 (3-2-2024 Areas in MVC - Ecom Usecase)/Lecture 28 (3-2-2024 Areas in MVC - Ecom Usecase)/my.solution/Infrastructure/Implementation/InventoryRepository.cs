using AutoMapper;
using DbModels;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly Evs409Context _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository _genericRepository;

        public InventoryRepository(Evs409Context context, IMapper mapper, IGenericRepository genericRepository)
        {
            _context = context;
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<List<CategoryVM>> CategoriesGetAll()
        {
            var CategoriesVM = new List<CategoryVM>();
            var Categories = await _context.Categories.Where(p => p.IsDeleted != true).OrderByDescending(p=>p.Id).ToListAsync();
            if (Categories != null && Categories.Count() > 0)
            {
                foreach (var item in Categories)
                {
                    var CategoryVM = _mapper.Map<CategoryVM>(item);
                    //var categoryVM = new CategoryVM();
                    //categoryVM.Id = item.Id;
                    //categoryVM.CategoryName = item.CategoryName;
                    //categoryVM.IsEnable = item.IsEnable;
                    //CategoriesVM.Add(categoryVM);
                    //CategoriesVM.Add(new CategoryVM()
                    //{
                    //    Id = item.Id,
                    //    IsEnable = item.IsEnable,
                    //    Name = item.CategoryName
                    //});
                    CategoriesVM.Add(CategoryVM);
                }
            }
            return CategoriesVM;
        }
        public async Task<bool> CategoryCreate(CategoryCreateVM model)
        {
            var Entity = new Category()
            {
                CategoryName = model.CategoryName,
                IsDeleted = false,
                IsEnable = model.IsEnable
            };
            return await _genericRepository.Create(Entity);
        }
        public async Task<bool> CategoryUpdate(CategoryUpdateVM model)
        {
            var Entity = await CategoryEntity(model.Id);   
            if (Entity == null) return false;

            Entity.IsEnable = model.IsEnable;
            Entity.CategoryName = model.CategoryName;

            return  await _genericRepository.Update(Entity);
        }
        public async Task<Category> CategoryEntity(int id)
        {
            var result = await _context.Categories.Where(p => p.Id == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<bool> CategoryDelete(int id)
        {
            var Entity = await CategoryEntity(id);
            if (Entity == null) return false;

            Entity.IsDeleted = true;

            return await _genericRepository.Update(Entity);

        }



    }
}
