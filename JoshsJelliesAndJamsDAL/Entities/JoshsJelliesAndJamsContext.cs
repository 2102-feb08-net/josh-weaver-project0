using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JoshsJelliesAndJams.DAL
{
    public partial class JoshsJelliesAndJamsContext : DbContext
    {
        public JoshsJelliesAndJamsContext()
        {
        }

        public JoshsJelliesAndJamsContext(DbContextOptions<JoshsJelliesAndJamsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerCreated).HasPrecision(0);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StreetAddress1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StreetAddress2).HasMaxLength(100);

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.DefaultStore)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DefaultStoreId)
                    .HasConstraintName("FK__Customer__Defaul__5FB337D6");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__6E01572D");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Inventory__Store__6D0D32F4");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DatePlaced).HasPrecision(0);

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__7D439ABD");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreId__7E37BEF6");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.TotalCost).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__01142BA1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__02084FDA");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Name, "UQ__Product__737584F6252CC389")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.Name, "UQ__Store__737584F620437388")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StreetAddress1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StreetAddress2).HasMaxLength(100);

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
