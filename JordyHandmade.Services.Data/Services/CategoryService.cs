namespace JordyHandmade.Services.Data.Services
{
    using Microsoft.EntityFrameworkCore;

    using JordyHandmade.Data;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Category;
    using JordyHandmade.Data.Models;    

    public class CategoryService : ICategoryService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public CategoryService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }		

		public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<CategorySelectViewModel>> GetAllCategoriesForSelectAsync()
        {
            IEnumerable<CategorySelectViewModel> allCategories = await this.dbContext
                .Categories
                .Select(c => new CategorySelectViewModel() 
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    //Description = c.Description,
                })
                .ToArrayAsync();

            return allCategories;
        }

		public async Task AddCategoryAsync(CategoryFormModel inputModel)
		{
			Category category = new Category() 
            {
                CategoryName = inputModel.CategoryName,
                Description = inputModel.Description
            };

			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();
		}

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryAllViewModel> allCategories = await this.dbContext
                .Categories                
                .Select(c => new CategoryAllViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    IsActive = c.IsActive                    
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<CategoryFormModel> GetCategoryByIdAsync(int id)
        {
            Category category = await this.dbContext
                .Categories.FirstAsync(c => c.Id == id);

            return new CategoryFormModel() 
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description            
            };            
        }

        public async Task UpdateCategoryAsync(int id, CategoryFormModel editModel)
        {
            Category categoryToUpdate = await this.dbContext
                .Categories.FirstAsync(c => c.Id == id);
                       
            categoryToUpdate.CategoryName = editModel.CategoryName;
            categoryToUpdate.Description = editModel.Description;            

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Category categoryToDelete = await this.dbContext
              .Categories.FirstAsync(c => c.Id == id);
                        
            categoryToDelete.IsActive = false;
            
            await this.dbContext.SaveChangesAsync();
        }
    }
}
