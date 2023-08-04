namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Customer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<CustomerFormModel> GetCustomerToEditAsync(string customerId);

        Task<string?> GetCustomerNameAsync(string customerId);

        Task AddCustomerDataAsync(string customerId, CustomerFormModel customerModel);
    }
}
