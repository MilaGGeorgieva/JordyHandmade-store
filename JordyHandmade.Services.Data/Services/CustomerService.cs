namespace JordyHandmade.Services.Data.Services
{
    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Customer;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class CustomerService : ICustomerService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public CustomerService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }		

		public async Task<CustomerFormModel> GetCustomerToEditAsync(string customerId)
        {
            Customer customerToEdit = await this.dbContext
                .Customers.FirstAsync(c => c.Id.ToString() == customerId);

            return new CustomerFormModel()
            {
                Name = customerToEdit.CustomerName,
                StreetAddress = customerToEdit.Address?.StreetAddress,
                TownName = customerToEdit.Address?.Town?.TownName,
                ZipCode = customerToEdit.Address?.Town?.ZipCode,
                PhoneNumber = customerToEdit.PhoneNumber,
                Email = customerToEdit.Email
            };
        }

		public async Task AddCustomerDataAsync(string customerId, CustomerFormModel customerModel)
		{
            Customer customerToEdit = await this.dbContext
                .Customers.FirstAsync(c => c.Id.ToString() == customerId);
                       
            bool addressExists = await this.dbContext
                .Addresses.AnyAsync(a => a.Customers.Any(c => c.Id.ToString() == customerId));
            bool townExists = await this.dbContext
                .Towns.AnyAsync(t => t.Addresses.Any(a => a.Customers.Any(c => c.Id.ToString() == customerId)));

            if (!townExists)
            {
                Town town = new Town()
                {
                    TownName = customerModel.TownName,
                    ZipCode = customerModel.ZipCode
                };

                await dbContext.Towns.AddAsync(town);
                await dbContext.SaveChangesAsync();
            }

            var customerTown = await this.dbContext
                .Towns
                .Where(t => t.Addresses.Any(a => a.Customers.Any(c => c.Id.ToString() == customerId)))
                .FirstAsync();
            
            if (!addressExists)
            {
                Address address = new Address()
                {
                    StreetAddress = customerModel.StreetAddress,
                    TownId = customerTown.Id                    
                };

                await dbContext.Addresses.AddAsync(address);
                await dbContext.SaveChangesAsync();
            }
            
            var customerAddress = await this.dbContext
                .Addresses
                .Where(a => a.Customers.Any(c => c.Id.ToString() == customerId))
                .FirstAsync();

            customerToEdit.CustomerName = customerModel.Name;
            customerToEdit.AddressId = customerAddress.Id;            
            customerToEdit.PhoneNumber = customerModel.PhoneNumber;
            customerToEdit.Email = customerModel.Email;

            await dbContext.SaveChangesAsync();
		}
	}
}
