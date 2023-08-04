namespace JordyHandmade.Services.Data.Services
{
    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Customer;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;
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
                .Customers
                .Include(c => c.Address)
                .ThenInclude(a => a.Town)
                .FirstAsync(c => c.Id.ToString() == customerId);

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
                                   
            bool townExists = await this.dbContext
                .Towns.AnyAsync(t => t.ZipCode == customerModel.ZipCode);   

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
                .Where(t => t.ZipCode == customerModel.ZipCode)
                .FirstAsync();

			bool customerAddressExists = await this.dbContext
				.Addresses.AnyAsync(a => a.Customers.Any(c => c.Id.ToString() == customerId));

			string enteredAddressNormalized = Regex.Replace(customerModel.StreetAddress, @"\s", "").ToLower();
			
            var addresses = await this.dbContext
			                .Addresses
			                .Where(a => a.Town.ZipCode == customerModel.ZipCode)
			                .ToArrayAsync();

            if (!customerAddressExists)
            {
                bool addressExists = false;

                foreach (var address in addresses)
				{
					string dbAddressNormalized = Regex.Replace(address.StreetAddress, @"\s", "").ToLower();

					if (dbAddressNormalized == enteredAddressNormalized)
					{
                        customerToEdit.AddressId = address.Id;
                        addressExists = true;
						break;
					}
				}

                if (addressExists == false)
                {
					Address newAddress = new Address()
					{
						StreetAddress = customerModel.StreetAddress,
						TownId = customerTown.Id,
						Customers = new HashSet<Customer>()
					    {
						    customerToEdit
					    }
					};

					await dbContext.Addresses.AddAsync(newAddress);
				}
				                				
				await dbContext.SaveChangesAsync();
			}
                       
            //var customerAddress = await this.dbContext
            //    .Addresses
            //    .Where(a => a.Customers.Any(c => c.Id.ToString() == customerId))
            //    .FirstAsync();

            customerToEdit.CustomerName = customerModel.Name;
            //customerToEdit.AddressId = customerAddress.Id;            
            customerToEdit.PhoneNumber = customerModel.PhoneNumber;
            customerToEdit.Email = customerModel.Email;

            await dbContext.SaveChangesAsync();
		}

        public async Task<string?> GetCustomerNameAsync(string customerId)
        {
            var customer = await this.dbContext.Users.FindAsync(customerId);

            if (string.IsNullOrEmpty(customer?.CustomerName))
            {
                return null;
            }

            return customer.CustomerName;
        }
    }
}
