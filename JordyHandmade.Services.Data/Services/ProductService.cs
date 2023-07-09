using JordyHandmade.Data;
using JordyHandmade.Services.Data.Interfaces;
using JordyHandmade.Web.ViewModels.Home;
using JordyHandmade.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Services.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public ProductService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public async Task<IEnumerable<IndexViewModel>> LastThreeProductsAsync()
        {
            IEnumerable<IndexViewModel> lastThreeProducts = await this.dbContext
                .Products
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ImageUrl = p.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeProducts;
        }

        public async Task<IEnumerable<AllViewModel>> GetAllAsync()
        {
            IEnumerable<AllViewModel> allProducts = await this.dbContext
                .Products.Select(p => new AllViewModel() 
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToArrayAsync();

            return allProducts;
        }


    }
}
