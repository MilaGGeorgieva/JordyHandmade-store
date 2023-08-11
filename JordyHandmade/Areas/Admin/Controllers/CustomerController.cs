namespace JordyHandmade.Web.Areas.Admin.Controllers
{
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Customer;
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : BaseAdminController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        public async Task<IActionResult> All()
        {
            IEnumerable<CustomerViewModel> allCustomers = 
                await this.customerService.GetAllCustomersAsync();

            return View(allCustomers);
        }
    }
}
