namespace JordyHandmade.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Category;    
    using static JordyHandmade.Common.NotificationMessagesConstants;
    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Web.ViewModels.Order;

    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Add()
        {
            CategoryFormModel inputModel = new CategoryFormModel();
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryFormModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                await categoryService.AddCategoryAsync(inputModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while adding the new category!" +
                    "Please try again later.";

                return View(inputModel);
            }

            return RedirectToAction("Index", "Home");            
        }

        public async Task<IActionResult> All() 
        {
            IEnumerable<CategoryAllViewModel> allCategories =
                await this.categoryService.GetAllCategoriesAsync();

            return View(allCategories);
        }

        public async Task<IActionResult> Edit(int id)
        {            
            bool categoryExists = await this.categoryService.ExistsByIdAsync(id);

            if (!categoryExists)
            {
                TempData[ErrorMessage] = "Category with the provided id does not exist!";

                return RedirectToAction("All");
            }
            try
            {
                CategoryFormModel editModel = await this.categoryService.GetCategoryByIdAsync(id);
        
                return View(editModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred! Try again!";
                return RedirectToAction("All");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryFormModel editModel)
        {
            bool categoryExists = await this.categoryService.ExistsByIdAsync(id);

            if (!categoryExists)
            {
                TempData[ErrorMessage] = "Category with the provided id does not exist!";

                return RedirectToAction("All");
            }

            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                await categoryService.UpdateCategoryAsync(id, editModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while editing selected category!");
                return View(editModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool categoryExists = await this.categoryService.ExistsByIdAsync(id);

            if (!categoryExists)
            {
                TempData[ErrorMessage] = "Category with the provided id does not exist!";

                return RedirectToAction("All");
            }             

            try
            {
                CategoryFormModel deleteModel = await this.categoryService.GetCategoryByIdAsync(id);            

                return View(deleteModel);
            }
            catch (Exception)
            {
                    TempData[ErrorMessage] = "Unexpected error occurred! Try again!";
                    return RedirectToAction("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CategoryFormModel deleteModel)
        {
            bool categoryExists = await this.categoryService.ExistsByIdAsync(id);

            if (!categoryExists)
            {
                TempData[ErrorMessage] = "Category with the provided id does not exist!";

                return RedirectToAction("All");
            }             

            try
            {
                await this.categoryService.DeleteCategoryAsync(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting selected category!");
                return View(deleteModel);
            }

            TempData[SuccessMessage] = "Selected category was deleted successfully!";
            return RedirectToAction("All");
        }
    }
}
