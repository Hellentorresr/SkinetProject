using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            //Brands table
            if (!context.Brands.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                //storing the data into the database
                context.Brands.AddRange(brands);
            }


            //ProductType Table
            if (!context.ProductTypes.Any())
            {
                var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                var producTypes = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                //storing the data into the database
                context.ProductTypes.AddRange(producTypes);
            }

            //Product Table
            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Products>>(productData);

                //storing the data into the database
                context.Products.AddRange(products);
            }



            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
