using Microsoft.EntityFrameworkCore;
using MindboxTestTaskQuery.Domain.DirtModels;
using MindboxTestTaskQuery.Domain.Models;

namespace MindboxTestTaskQuery.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
        public virtual DbSet<DirtProduct> DirtProducts { get; set; }
        public virtual DbSet<DirtCategory> DirtCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(sc => sc.Category)
                .WithMany(s => s.CategoryProducts)
                .HasForeignKey(sc => sc.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(sc => sc.Product)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { Id = 1, Name = "Apple" },
                new Product { Id = 2, Name = "Samsung" },
                new Product { Id = 3, Name = "Xiaomi" },
                new Product { Id = 4, Name = "Logitech" },
                new Product { Id = 5, Name = "Microsoft" },
                new Product { Id = 6, Name = "Coffee" },
                new Product { Id = 7, Name = "Cookies" },
            });

            modelBuilder.Entity<CategoryProduct>().HasData(new CategoryProduct[]
            {
                new CategoryProduct { Id = 1, ProductId = 6 },
                new CategoryProduct { Id = 2, ProductId = 7 },
                new CategoryProduct { Id = 3, ProductId = 1, CategoryId = 5 },
                new CategoryProduct { Id = 4, ProductId = 2, CategoryId = 5 },
                new CategoryProduct { Id = 5, ProductId = 2, CategoryId = 1 },
                new CategoryProduct { Id = 6, ProductId = 2, CategoryId = 2 },
                new CategoryProduct { Id = 7, ProductId = 2, CategoryId = 3 },
                new CategoryProduct { Id = 8, ProductId = 3, CategoryId = 1 },
                new CategoryProduct { Id = 9, ProductId = 3, CategoryId = 2 },
                new CategoryProduct { Id = 10, ProductId = 3, CategoryId = 3 },
                new CategoryProduct { Id = 11, ProductId = 4, CategoryId = 1 },
                new CategoryProduct { Id = 12, ProductId = 5, CategoryId = 4 },
            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Computer peripherals" },
                new Category { Id = 2, Name = "TV's" },
                new Category { Id = 3, Name = "Laptops" },
                new Category { Id = 4, Name = "Softwares" },
                new Category { Id = 5, Name = "Phones" },
            });

            modelBuilder.Entity<DirtCategory>().HasData(new DirtCategory[]
            {
                new DirtCategory { Id = 1, CategoryId = 1, Name = "Computer peripherals", ProductId = 4 },
                new DirtCategory { Id = 2, CategoryId = 1, Name = "Computer peripherals", ProductId = 2 },
                new DirtCategory { Id = 3, CategoryId = 1, Name = "Computer peripherals", ProductId = 3 },
                new DirtCategory { Id = 4, CategoryId = 2, Name = "TV's", ProductId = 2 },
                new DirtCategory { Id = 5, CategoryId = 2, Name = "TV's", ProductId = 3 },
                new DirtCategory { Id = 6, CategoryId = 3, Name = "Laptops" },
                new DirtCategory { Id = 7, CategoryId = 4, Name = "Softwares" },
                new DirtCategory { Id = 8, CategoryId = 5, Name = "Phones", ProductId = 1 },
                new DirtCategory { Id = 9, CategoryId = 5, Name = "Phones", ProductId = 2 },
                new DirtCategory { Id = 10, CategoryId = 5, Name = "Phones", ProductId = 3 },
            });

            modelBuilder.Entity<DirtProduct>().HasData(new DirtProduct[]
            {
                new DirtProduct { Id = 1, ProductId = 1, Name = "Apple", CategoryId =  5},
                new DirtProduct { Id = 2, ProductId = 2, Name = "Samsung", CategoryId = 5 },
                new DirtProduct { Id = 3, ProductId = 3, Name = "Xiaomi", CategoryId = 5 },
                new DirtProduct { Id = 4, ProductId = 4, Name = "Logitech", CategoryId = 1 },
                new DirtProduct { Id = 5, ProductId = 2, Name = "Samsung", CategoryId = 1 },
                new DirtProduct { Id = 6, ProductId = 3, Name = "Xiaomi", CategoryId = 1 },
                new DirtProduct { Id = 7, ProductId = 2, Name = "Samsung", CategoryId = 2 },
                new DirtProduct { Id = 8, ProductId = 3, Name = "Xiaomi", CategoryId = 2 },
                new DirtProduct { Id = 9, ProductId = 5, Name = "Microsoft", CategoryId = 4 },
                new DirtProduct { Id = 10, ProductId = 6, Name = "Coffee" },
                new DirtProduct { Id = 11, ProductId = 7, Name = "Cookies" },
            });
        }
    }
}