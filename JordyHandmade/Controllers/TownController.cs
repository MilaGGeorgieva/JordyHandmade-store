namespace JordyHandmade.Web.Controllers
{
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Town;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TownController : Controller
    {
        private readonly ITownService townService;

        public TownController(ITownService townService)
        {
            this.townService = townService;
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
                ModelState.AddModelError(nameof(inputModel.ZipCode), "A town with this Zip code already exists! ");
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
            //return this.RedirectToAction("AdminPage", "Admin");
        }
    }
}
