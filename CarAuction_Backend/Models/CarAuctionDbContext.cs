using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarAuction_Backend.Models;

public partial class CarAuctionDbContext : DbContext
{
    public CarAuctionDbContext()
    {
    }

    public CarAuctionDbContext(DbContextOptions<CarAuctionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=CarAuctionDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auction__3213E83FD86DC360");

            entity.ToTable("Auction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyerId).HasColumnName("buyerId");
            entity.Property(e => e.CarId).HasColumnName("carId");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");
            entity.Property(e => e.StartingBid).HasColumnName("startingBid");

            entity.HasOne(d => d.Buyer).WithMany(p => p.AuctionBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Auction__buyerId__5CD6CB2B");

            entity.HasOne(d => d.Car).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Auction__carId__5BE2A6F2");

            entity.HasOne(d => d.Seller).WithMany(p => p.AuctionSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Auction__sellerI__5DCAEF64");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bid__3213E83FFD6520D1");

            entity.ToTable("Bid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BidAmmount).HasColumnName("bidAmmount");
            entity.Property(e => e.BuyerId).HasColumnName("buyerId");
            entity.Property(e => e.CarId).HasColumnName("carId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Bids)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Bid__buyerId__619B8048");

            entity.HasOne(d => d.Car).WithMany(p => p.Bids)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Bid__carId__60A75C0F");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3213E83FE8EC661C");

            entity.ToTable("Car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City_Mpg).HasColumnName("city_mpg");
            entity.Property(e => e.Class)
                .HasMaxLength(100)
                .HasColumnName("class");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .HasColumnName("color");
            entity.Property(e => e.Combination_Mpg).HasColumnName("combination_mpg");
            entity.Property(e => e.Cylinders).HasColumnName("cylinders");
            entity.Property(e => e.Displacement).HasColumnName("displacement");
            entity.Property(e => e.Drive)
                .HasMaxLength(20)
                .HasColumnName("drive");
            entity.Property(e => e.Fuel_Type)
                .HasMaxLength(20)
                .HasColumnName("fuel_type");
            entity.Property(e => e.Highway_Mpg).HasColumnName("highway_mpg");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Make)
                .HasMaxLength(100)
                .HasColumnName("make");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.Transmission)
                .HasMaxLength(100)
                .HasColumnName("transmission");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Seller).WithMany(p => p.Cars)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Car__sellerId__59063A47");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F843C8118");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(255)
                .HasColumnName("streetAddress");
            entity.Property(e => e.Zip)
                .HasMaxLength(20)
                .HasColumnName("zip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
