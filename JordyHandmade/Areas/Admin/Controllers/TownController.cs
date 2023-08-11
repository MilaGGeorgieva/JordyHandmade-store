namespace JordyHandmade.Web.Areas.Admin.Controllers
{    
    using Microsoft.AspNetCore.Mvc;

    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Web.ViewModels.Town;
    using JordyHandmade.Web.Areas.Admin.ViewModels.Town;
    using static JordyHandmade.Common.NotificationMessagesConstants;

    public class TownController : BaseAdminController
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
                Towns = await townService.GetAllForSelectAsync()
            };

            return View(selectModel);
        }

        [HttpPost]
        public IActionResult AllForSelect(TownSelectViewModel selectModel)
        {
            return RedirectToAction("Change", new { selectModel.Id });
        }

        public async Task<IActionResult> Change(int id)
        {
            TownFormModel changeModel = await townService.GetTownByIdAsync(id);

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

            bool townExists = await townService.TownExistsByZipAsync(inputModel.ZipCode);

            if (townExists)
            {
                //TempData[ErrorMessage] = "A town with this Zip code already exists!";
                ModelState.AddModelError(nameof(inputModel.ZipCode), "A town with this Zip code already exists!");
                return View(inputModel);
            }

            try
            {
                await townService.AddTownAsync(inputModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while adding the new town!" +
                    "Please try again later.";

                return View(inputModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            try
            {
                TownFormModel editModel = await townService.GetTownByIdAsync(id);
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
                await townService.UpdateAsync(id, editModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while editing selected town!");
                return View(editModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            try
            {
                TownFormModel formModel = await townService.GetTownByIdAsync(id);
                return View(formModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
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
                await townService.DeleteAsync(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting this town!");
                return View(formModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
