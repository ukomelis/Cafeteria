using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaAPI.Postgre
{
    public class CafeteriaContext : DbContext
    {
        public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>()
                .HasData(
                    new ProductType { Id = 1, Name = "Food" },
                    new ProductType { Id = 2, Name = "Other" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Brownie", Price = 0.65m, Stock = 48, ProductTypeId = 0},
                    new Product { Id = 2, Name = "Muffin", Price = 1.00m, Stock = 36, ProductTypeId = 0 },
                    new Product { Id = 3, Name = "Cake Pop", Price = 1.35m, Stock = 24, ProductTypeId = 0 },
                    new Product { Id = 4, Name = "Apple tart", Price = 1.50m, Stock = 60, ProductTypeId = 0 },
                    new Product { Id = 5, Name = "Water", Price = 1.50m, Stock = 30, ProductTypeId = 0 },
                    
                    new Product { Id = 6, Name = "Shirt", Price = 2.00m, ProductTypeId = 1, Stock = 0 },
                    new Product { Id = 7, Name = "Pants", Price = 3.00m, ProductTypeId = 1, Stock = 0 },
                    new Product { Id = 8, Name = "Jacket", Price = 4.00m, ProductTypeId = 1, Stock = 0 },
                    new Product { Id = 9, Name = "Toy", Price = 1.00m, ProductTypeId = 1, Stock = 0 }
                );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        
    }

    public class ProductType
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }

    public class Product
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int ProductTypeId { get; set; }
    }
}
