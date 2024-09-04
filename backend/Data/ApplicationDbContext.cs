using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(c => c.TotalPrice)
                .HasColumnType("decimal(18,2)") 
                .HasPrecision(18, 2);
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)") 
            .HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)") 
            .HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>()
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)") 
            .HasPrecision(18, 2);
            modelBuilder.Entity<CartItem>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,2)") 
            .HasPrecision(18, 2);
        }
    }
}
