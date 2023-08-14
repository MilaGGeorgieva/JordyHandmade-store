namespace JordyHandmade.Services.Tests
{
	using JordyHandmade.Data;
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Services.Data.Services;
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

			Assert.True(result);
		}
	}
}