namespace JordyHandmade.Services.Tests
{
	using JordyHandmade.Data;
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Services.Data.Services;
	using JordyHandmade.Web.ViewModels.Product;
	using Microsoft.EntityFrameworkCore;
	using Moq;
	using static DatabaseSeeder;

	public class ProductServiceTests
	{
		private DbContextOptions<JordyHandmadeDbContext> dbContextOptions;
		private JordyHandmadeDbContext dbContext;
		//private Mock<JordyHandmadeDbContext> dbMock;

		private IProductService productService;

		public ProductServiceTests()
		{

		}

		[OneTimeSetUp]
		public void OneTimeSetUp() 
		{
			this.dbContextOptions = new DbContextOptionsBuilder<JordyHandmadeDbContext>()
				.UseInMemoryDatabase("JordyHandmadeInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new JordyHandmadeDbContext(this.dbContextOptions, false);
			
			this.dbContext.Database.EnsureCreated();
			SeedDatabase(this.dbContext);

			this.productService = new ProductService(this.dbContext);
		}
		
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task ExistsByIdAsyncReturnsTrueWhenExists()
		{
			string existingProductId = Product.Id.ToString();

			bool result = await this.productService.ExistsByIdAsync(existingProductId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task GetQuantityInStockByIdReturnsCorrectQuantityInStock() 
		{
			string productId = Product.Id.ToString();

			int result = await this.productService.GetQuantityInStockByIdAsync(productId); 

			Assert.That(result, Is.EqualTo(Product.QuantityInStock));
		}

		[Test]
		public async Task AddProductShouldWorkCorrectly() 
		{
			int productCountBeforeAdd = dbContext.Products.Count();

			ProductFormModel inputModel = new ProductFormModel() 
			{
				Name = "Test2",
				Description = "Lorem ipsum dolor sit amet",
				ImageUrl = "Image url link here for test",
				Price = 10.5m,
				CreatedOn = "2023-08-15",
				QuantityInStock = 3,
				CategoryId = 2
			};

			await productService.AddProductAsync(inputModel);

			int productCountAfterAdd = dbContext.Products.Count();
			Assert.That(productCountAfterAdd, Is.EqualTo(productCountBeforeAdd + 1));

			var newProduct = await this.dbContext.Products
				.FirstOrDefaultAsync(p => p.Name == "Test2" && 
							p.CreatedOn.ToString("yyyy-MM-dd") == "2023-08-15" && 
							p.CategoryId == 2);			

			Assert.IsNotNull(newProduct);
			Assert.That(newProduct.Name, Is.EqualTo(inputModel.Name));
			Assert.That(newProduct.Description, Is.EqualTo(inputModel.Description));
			Assert.That(newProduct.ImageUrl, Is.EqualTo(inputModel.ImageUrl));
			Assert.That(newProduct.Price, Is.EqualTo(inputModel.Price));
			Assert.That(newProduct.CreatedOn.ToString("yyyy-MM-dd"), Is.EqualTo(inputModel.CreatedOn));
			Assert.That(newProduct.QuantityInStock, Is.EqualTo(inputModel.QuantityInStock));
			Assert.That(newProduct.CategoryId, Is.EqualTo(inputModel.CategoryId));
		} 
	}
}