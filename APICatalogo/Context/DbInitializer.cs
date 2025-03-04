using APICatalogo.Models;

namespace APICatalogo.Context;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {

        if (context.Categories.Any() || context.Products.Any())
        {
            return;
        }


        var categories = new Category[]
        {
        new Category
        {
            CategoryId = 1,
            Name = "Eletrônicos",
            ImageUrl = "eletronicos.jpg"
        },
        new Category
        {
            CategoryId = 2,
            Name = "Roupas",
            ImageUrl = "roupas.jpg"
        }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges(); 

        // Cria os produtos
        var products = new Product[]
        {
        new Product
        {
            ProductId = 1,
            Name = "Smartphone",
            Description = "Um smartphone top de linha",
            Price = 2500.00m,
            ImageUrl = "smartphone.jpg",
            Stock = 10,
            CreateDate = DateTime.Now,
            CategoryId = 1 
        },
        new Product
        {
            ProductId = 2,
            Name = "Camiseta",
            Description = "Uma camiseta confortável",
            Price = 50.00m,
            ImageUrl = "camiseta.jpg",
            Stock = 20,
            CreateDate = DateTime.Now,
            CategoryId = 2 
        }
        };

        context.Products.AddRange(products);
        context.SaveChanges(); 
    }
}
