using Microsoft.EntityFrameworkCore;
using OnTapThiCuoiKy.Entities;

namespace OnTapThiCuoiKy.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Shop> Shops {get; set;}
        public DbSet<Provider> Providers { get; set;}
        public DbSet<ShopProvider> ShopProviders { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //cấu hình quan hệ
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique(true);
            });
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasMany(shop => shop.Provider)
                .WithMany(provider => provider.Shop)
                .UsingEntity<ShopProvider>(
                    r => r.HasOne(e => e.Provider).WithMany(c => c.ShopProvider).HasForeignKey(c => c.IdProvider),
                    l => l.HasOne(e => e.Shop).WithMany(c => c.ShopProvider).HasForeignKey(c => c.IdShop)
                    );
            });
            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique(true);
            });
            modelBuilder.Entity<ShopProvider>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
        }
    }
}
