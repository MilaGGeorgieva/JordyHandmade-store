namespace JordyHandmade.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using Moq;
	using Moq.EntityFrameworkCore;

	using JordyHandmade.Data;
	using JordyHandmade.Data.Models;
	using static DbMockSeedData;
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Services.Data.Services;

	public class ProductServiceTests
	{
		private DbContextOptions<JordyHandmadeDbContext> dbContextOptions;
		private JordyHandmadeDbContext dbContext;
		private Mock<JordyHandmadeDbContext> dbMock;

		public ProductServiceTests()
		{

		}

		[OneTimeSetUp]
		public void OneTimeSetUp() 
		{
			this.dbContextOptions = new DbContextOptionsBuilder<JordyHandmadeDbContext>()
				.UseInMemoryDatabase("JordyHandmadeInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new JordyHandmadeDbContext(this.dbContextOptions);
		}
		
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ExistsByIdAsyncReturnsTrueWhenExists()
		{
			//var mock = new Mock<JordyHandmadeDbContext>()
			//	.Setup(db => db.Products)
			//	.ReturnsDbSet(Products);			
		}
	}
}