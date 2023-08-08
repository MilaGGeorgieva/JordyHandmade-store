namespace JordyHandmade.Web.Controllers
{
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Web.ViewModels.Town;
    using static JordyHandmade.Common.GeneralApplicationConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
        
    [Authorize(Roles = AdminRoleName)]
    public class TownController : Controller
    {
        private readonly ITownService townService;

        public TownController(ITownService townService)
        {
            this.townService = townService;
        }

        public async Task<IActionResult> AllForSelect() 
        {
            TownSelectViewModel selectModel = new TownSelectViewModel() 
            {
               Towns = await this.townService.GetAllForSelectAsync()
            };
                        
            return View(selectModel);
        }

        [HttpPost]
        public IActionResult AllForSelect(TownSelectViewModel selectModel) 
        {            
            return RedirectToAction("Change", new { Id = selectModel.Id });
        }

        public async Task<IActionResult> Change(int id) 
        {
            TownFormModel changeModel = await this.townService.GetTownByIdAsync(id);

            return View(changeModel);
        }
         
        public IActionResult Add()
        {            
            TownFormModel inputModel = new TownFormModel();
            
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TownFormModel inputModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool townExists = await this.townService.TownExistsByZipAsync(inputModel.ZipCode);

            if (townExists)
            {
                ModelState.AddModelError(nameof(inputModel.ZipCode), "A town with this Zip code already exists!");
                return this.View(inputModel);
            }

            try
            {                
                await this.townService.AddTownAsync(inputModel);
            }
            catch (Exception)
            {
                return this.View(inputModel);                
            }

            return this.RedirectToAction("Index", "Home");            
        }

        public async Task<IActionResult> Edit(int id) 
        {
			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}
            try
            {
                TownFormModel editModel = await this.townService.GetTownByIdAsync(id);
                return View(editModel);
            }
            catch (Exception)
            {
                return BadRequest();                
            }

		}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TownFormModel editModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                await this.townService.UpdateAsync(id, editModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while editing selected town!");
                return this.View(editModel);
            }

            return this.RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Delete(int id) 
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            try
            {
                TownFormModel formModel = await this.townService.GetTownByIdAsync(id);
                return this.View(formModel);
            }
            catch (Exception)
            {
				return this.RedirectToAction("Index", "Home");								
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, TownFormModel formModel) 
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            try
            {
                await this.townService.DeleteAsync(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting this town!");
                return this.View(formModel);
            }

            return this.RedirectToAction("Index", "Home");			
		}
	}
}
