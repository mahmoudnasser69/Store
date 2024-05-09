using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context , ILoggerFactory loggerFactory)
        {
			try
			{
				if(context.ProductBrands != null && !context.ProductBrands.Any())
				{
					var BrandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
					var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
					if(Brands is not  null )
	                    await context.ProductBrands.AddRangeAsync(Brands);
				}
                if (context.productTypes != null && !context.productTypes.Any())
                {
                    var TypesData = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    if (Types is not null)
                        await context.AddRangeAsync(Types);
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var ProductData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    if (Products is not null)
                        await context.Products.AddRangeAsync(Products);
                }
                if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
                {
                    var DeliveryMethodData = File.ReadAllText("../Store.Repository/SeedData/delivery.json");
                    var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodData);
                    if (deliveryMethods is not null)
                        await context.DeliveryMethods.AddRangeAsync(deliveryMethods);
                }
                await context.SaveChangesAsync();

            }
			catch (Exception ex)
			{
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();

                logger.LogError(ex.Message);
			}

        }
    }
}
