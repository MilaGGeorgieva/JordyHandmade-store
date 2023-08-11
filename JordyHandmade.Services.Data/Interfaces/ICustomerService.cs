namespace JordyHandmade.Services.Data.Interfaces
{
    using JordyHandmade.Web.ViewModels.Customer;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();

        Task<CustomerFormModel> GetCustomerToEditAsync(string customerId);

        Task<string?> GetCustomerNameAsync(string customerId);

        Task AddCustomerDataAsync(string customerId, CustomerFormModel customerModel);
    }
}
