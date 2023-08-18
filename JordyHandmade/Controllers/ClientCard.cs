namespace JordyHandmade.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ClientCard : Controller
    {
        public IActionResult BonusPoints()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
