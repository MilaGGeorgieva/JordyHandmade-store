namespace JordyHandmade.Services.Data.Services
{
    using Microsoft.EntityFrameworkCore;

    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Home;
    using JordyHandmade.Web.ViewModels.Product;    

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

		public async Task<DetailsViewModel> GetDetailsAsync(string id)
		{
            DetailsViewModel detailsModel = await this.dbContext
                .Products
                .Select(p => new DetailsViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock
                })
                .FirstAsync(p => p.Id == id);

            return detailsModel;
		}

        public async Task<bool> ExistsByIdAsync(string id)
        {
            bool result = await this.dbContext
                .Products
                .AnyAsync(p => p.Id.ToString() == id);

            return result;
        }

        public async Task<int> GetQuantityInStockByIdAsync(string id)
        {
            Product product = await this.dbContext
                .Products
                .FirstAsync(p => p.Id.ToString() == id);

            int result = product.QuantityInStock;

            return result;
        }

        public async Task AddProductAsync(ProductFormModel formModel)
        {
            Product product = new Product() 
            {
                Name = formModel.Name,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                CreatedOn = DateTime.Parse(formModel.CreatedOn),
                QuantityInStock = formModel.QuantityInStock,
                CategoryId = formModel.CategoryId,
            };

            await this.dbContext.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProductFormModel> GetProductToEditAsync(string id)
        {
            Product productToEdit = await this.dbContext
                .Products.FirstAsync(p => p.Id.ToString() == id);

            return new ProductFormModel()
            {
                Name = productToEdit.Name,
                Description = productToEdit.Description,
                ImageUrl = productToEdit.ImageUrl,
                Price = productToEdit.Price,
                CreatedOn = productToEdit.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                QuantityInStock = productToEdit.QuantityInStock,
                CategoryId = productToEdit.CategoryId
            };
        }

        public async Task UpdateAsync(string id, ProductFormModel editModel)
        {
            Product productToEdit = await this.dbContext
                .Products.FirstAsync(p => p.Id.ToString() == id);

            productToEdit.Name = editModel.Name;
            productToEdit.Description = editModel.Description;
            productToEdit.ImageUrl = editModel.ImageUrl;
            productToEdit.Price = editModel.Price;
            productToEdit.CreatedOn = DateTime.Parse(editModel.CreatedOn);
            productToEdit.QuantityInStock = editModel.QuantityInStock;
            productToEdit.CategoryId = editModel.CategoryId;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
