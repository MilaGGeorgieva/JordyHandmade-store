﻿namespace JordyHandmade.Services.Tests
{
	using JordyHandmade.Data.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class DbMockSeedData
	{
		public static List<Product> Products = new List<Product>() 
		{
			new Product() 
			{
				Name = "Test1",
				Description = "Lorem Ipsum",
				ImageUrl = "/Images/ProductImages/HeartPillows.jpg",
				Price = 20.00M,
				CreatedOn = DateTime.UtcNow,
				QuantityInStock = 5,
				CategoryId = 1,
				IsObsolete = false
			},

			new Product() 
			{
				Name = "Test2",
				Description = "Lorem Ipsum, Lorem Ipsum",
				ImageUrl = "/Images/ProductImages/DenimBagSet.jpg",
				Price = 15.00M,
				CreatedOn = DateTime.UtcNow,
				QuantityInStock = 3,
				CategoryId = 2,
				IsObsolete = false
			}
		};
	}
}
