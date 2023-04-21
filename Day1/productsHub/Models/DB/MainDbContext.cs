using Microsoft.EntityFrameworkCore;
using productsHub.Models;

namespace productsHub.Models
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
                
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Description = "This is the first product", Price = 10, Quantity = 5, Image = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZHVjdHxlbnwwfHwwfHw%3D&w=1000&q=80" },
                new Product { Id = 2, Name = "Product 2", Description = "This is the second product", Price = 20, Quantity = 10, Image = "https://images.pexels.com/photos/90946/pexels-photo-90946.jpeg?cs=srgb&dl=pexels-math-90946.jpg&fm=jpg" },
                new Product { Id = 3, Name = "Product 3", Description = "This is the third product", Price = 30, Quantity = 15 , Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHw%3D&w=1000&q=80" }
            );

            // Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Text = "This is a comment for product 1", UserName = "User1", ProductId = 1 },
                new Comment { Id = 2, Text = "This is a comment for product 2", UserName = "User2", ProductId = 2 },
                new Comment { Id = 3, Text = "This is a comment for product 1", UserName = "User3", ProductId = 1 },
                new Comment { Id = 4, Text = "This is a comment for product 3", UserName = "User4", ProductId = 3 }
            );
        }
    }
}
