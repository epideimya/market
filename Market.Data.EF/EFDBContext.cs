using Market.Data.DataBaseModel;
using Microsoft.EntityFrameworkCore;
using System;


namespace Market.Data.EF
{
    public class EFDBContext : DbContext

    {
        public EFDBContext(string connectionString) : base(_getContextOptions(connectionString))
        {

        } 
        private static DbContextOptions<EFDBContext> _getContextOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.SellerId)
                    .IsRequired(true);
                builder.Property(x => x.PurchaseId)
                    .IsRequired(true);
                builder.Property(x => x.IsPaid)
                    .IsRequired(true);
                builder.Property(x => x.IsSent)
                    .IsRequired(true);

                builder.HasOne<Seller>()               //Описание связи
                    .WithMany()                        
                    .HasForeignKey(x => x.SellerId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<Purchaser>()
                    .WithMany()
                    .HasForeignKey(x => x.PurchaseId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
             });

            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.ProductId)
                    .IsRequired(true);
                builder.Property(x => x.Count)
                    .IsRequired(true);
                builder.Property(x => x.OrderId)
                    .IsRequired(true);

                builder.HasOne<Order>()
                    .WithMany()
                    .HasForeignKey(x => x.OrderId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired(true);
                builder.Property(x => x.Name)
                    .HasMaxLength(100);
                builder.Property(x => x.Count)
                    .IsRequired(true);
                builder.Property(x => x.Price)
                    .IsRequired(true);
                builder.Property(x => x.Description)
                    .IsRequired(true);
                builder.Property(x => x.Description)
                    .HasMaxLength(1000);
                builder.Property(x => x.MarketingInfo)
                    .IsRequired(true);
                builder.Property(x => x.MarketingInfo)
                    .HasMaxLength(10000);
                builder.Property(x => x.SellerId)
                    .IsRequired(true);
                builder.Property(x => x.ProductCategoryId)
                    .IsRequired(true);

                builder.HasOne<Seller>()
                    .WithMany()
                    .HasForeignKey(x => x.SellerId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<ProductCategory>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductCategoryId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductAttribute>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired(true);
                builder.Property(x => x.Name)
                    .HasMaxLength(100);
                builder.Property(x => x.Description)
                    .IsRequired(true);
                builder.Property(x => x.Description)
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<ProductAttributeValue>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.ProductAttributeId)
                    .IsRequired(true);
                builder.Property(x => x.ProductId)
                    .IsRequired(true);
                builder.Property(x => x.Value)
                    .IsRequired(true);
                builder.Property(x => x.Value)
                    .HasMaxLength(100);

                builder.HasOne<ProductAttribute>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductAttributeId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductCategory>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired(true);
                builder.Property(x => x.Name)
                    .HasMaxLength(100);
                builder.Property(x => x.ParentId)
                    .IsRequired(false);          
                    
                builder.HasOne<ProductCategory>()
                    .WithMany()
                    .HasForeignKey(x => x.ParentId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductImage>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.URL)
                    .IsRequired(true);
                builder.Property(x => x.ProductId)
                    .IsRequired(true);

                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductId)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Purchaser>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired(true);
                builder.Property(x => x.Mail)
                    .IsRequired(true);
                builder.Property(x => x.Phone)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Seller>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name)
                    .IsRequired(true);
                builder.Property(x => x.Mail)
                    .IsRequired(true);
                builder.Property(x => x.Phone)
                    .IsRequired(true);
            });
        }
    }
}
