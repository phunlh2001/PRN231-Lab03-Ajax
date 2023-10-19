using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;database=Lab3_Ajax");
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Beverages" },
                    new Category { CategoryId = 2, CategoryName = "Condiments" },
                    new Category { CategoryId = 3, CategoryName = "Confections" },
                    new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                    new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                    new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                    new Category { CategoryId = 7, CategoryName = "Produce" },
                    new Category { CategoryId = 8, CategoryName = "Seafood" }
               );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Coca Cola",
                    CategoryId = 1,
                    UnitPrice = 60,
                    UnitsInStock = 100
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Wellington Beef",
                    CategoryId = 6,
                    UnitPrice = 1200,
                    UnitsInStock = 100
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "King Crab",
                    CategoryId = 8,
                    UnitPrice = 1800,
                    UnitsInStock = 100
                }
            );
        }
    }
}
