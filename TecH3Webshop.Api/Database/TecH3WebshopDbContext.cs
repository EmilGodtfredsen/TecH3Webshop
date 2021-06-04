using Microsoft.EntityFrameworkCore;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Api.Database
{
    public class TecH3WebshopDbContext : DbContext
    {

        public TecH3WebshopDbContext() {}
        public TecH3WebshopDbContext(DbContextOptions<TecH3WebshopDbContext> options):base(options){}
        public DbSet<Login> Logins { get; set; }

        // realizes a unique constraint for Login.Email
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasAlternateKey(l => l.Email)
                .HasName("AlternateKey_Email");
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
