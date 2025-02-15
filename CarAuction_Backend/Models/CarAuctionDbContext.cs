﻿using System;
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
        => optionsBuilder.UseSqlServer("Data Source=carauction.database.windows.net;Initial Catalog=CarAuctionDB; User Id=CarAuctionAdmin; Password=CarAuction1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auction__3213E83F3BD8C91F");

            entity.ToTable("Auction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("carId");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");
            entity.Property(e => e.StartingBid).HasColumnName("startingBid");

            entity.HasOne(d => d.Car).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Auction__carId__66603565");

            entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Auction__sellerI__6754599E");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bid__3213E83FD7F5A1FB");

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
                .HasConstraintName("FK__Bid__carId__628FA481");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3213E83F9983F2C1");

            entity.ToTable("Car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityMpg).HasColumnName("city_mpg");
            entity.Property(e => e.Class)
                .HasMaxLength(100)
                .HasColumnName("class");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .HasColumnName("color");
            entity.Property(e => e.CombinationMpg).HasColumnName("combination_mpg");
            entity.Property(e => e.Cylinders).HasColumnName("cylinders");
            entity.Property(e => e.Displacement).HasColumnName("displacement");
            entity.Property(e => e.Drive)
                .HasMaxLength(20)
                .HasColumnName("drive");
            entity.Property(e => e.FuelType)
                .HasMaxLength(20)
                .HasColumnName("fuel_type");
            entity.Property(e => e.HighwayMpg).HasColumnName("highway_mpg");
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
                .HasConstraintName("FK__Car__sellerId__5EBF139D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FB97A2833");

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
