using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

public partial class WebDbContext : DbContext
{
    public WebDbContext()
    {
    }

    public WebDbContext(DbContextOptions<WebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComponentMaster> ComponentMasters { get; set; }

    public virtual DbSet<ComponentOperationMaster> ComponentOperationMasters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MachineManufacturer> MachineManufacturers { get; set; }

    public virtual DbSet<MachineMaster> MachineMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentMaster>(entity =>
        {
            entity.HasKey(e => e.ComponentId).HasName("ComponentMaster_pkey");

            entity.ToTable("ComponentMaster");

            entity.Property(e => e.ComponentId).ValueGeneratedNever();
            entity.Property(e => e.ComponentName).HasMaxLength(64);
            entity.Property(e => e.ECN)
                .HasMaxLength(16)
                .HasColumnName("ECN");
            entity.Property(e => e.PartNo).HasMaxLength(32);
        });

        modelBuilder.Entity<ComponentOperationMaster>(entity =>
        {
            entity.HasKey(e => e.TrNo).HasName("ComponentOperationMaster_pkey");

            entity.ToTable("ComponentOperationMaster");

            entity.Property(e => e.TrNo).HasDefaultValueSql("nextval('\"ComponentOperation_Trno_seq\"'::regclass)");
            entity.Property(e => e.OperationCode)
                .HasMaxLength(16)
                .HasColumnName("OperationCode");
            entity.Property(e => e.OperationDescription).HasColumnType("character varying");
            entity.Property(e => e.OperationName).HasMaxLength(64);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("Location_mst_pkey");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("LocationID");
            entity.Property(e => e.Latitude).HasPrecision(8, 6);
            entity.Property(e => e.LocationName).HasMaxLength(128);
            entity.Property(e => e.Longitude).HasPrecision(9, 6);
        });

        modelBuilder.Entity<MachineManufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("MachineManufacturer_pkey");

            entity.ToTable("MachineManufacturer");

            entity.Property(e => e.ManufacturerId).ValueGeneratedNever();
            entity.Property(e => e.ManufacturerName).HasMaxLength(128);
        });

        modelBuilder.Entity<MachineMaster>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("MachineMaster_pkey");

            entity.ToTable("MachineMaster");

            entity.Property(e => e.MachineId).ValueGeneratedNever();
            entity.Property(e => e.MachineModel)
                .HasMaxLength(16)
                .HasColumnName("MachineModel");
            entity.Property(e => e.MachineName).HasMaxLength(64);
            entity.Property(e => e.MachineSerialNumber)
                .HasMaxLength(16)
                .HasColumnName("MachineSerialNumber");
            entity.Property(e => e.YearofManufacture).HasColumnName("YearofManufacture");
            entity.Property(e => e.LoactionId).HasColumnName("LoactionId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.SrNo).HasName("Users_pkey");

            entity.Property(e => e.SrNo).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
