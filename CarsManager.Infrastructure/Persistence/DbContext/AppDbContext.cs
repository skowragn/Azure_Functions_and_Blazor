using CarsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsManager.Orleans.Infrastructure.Persistence.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<CarDetails> CarDetails { get; set; }
    public DbSet<CarCategories> CarCategories { get; set; }
    public DbSet<CarsBookedItem> CarsBookedItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarDetails>()
                    .HasKey(p => p.Id);

        modelBuilder.Entity<CarDetails>()
                    .Property(p => p.Name)
                    .IsRequired();

        modelBuilder.Entity<CarDetails>()
                    .Property(p => p.Engine)
                    .IsRequired();

        modelBuilder.Entity<CarDetails>()
                    .Property(p => p.Model)
                    .IsRequired();

        modelBuilder.Entity<CarDetails>()
                    .Property(p => p.Year)
                    .IsRequired();

        modelBuilder.Entity<CarDetails>()
                    .Property(p => p.Description);

        modelBuilder.Entity<CarsBookedItem>()
                    .HasKey(p => p.Id);

        modelBuilder.Entity<CarsBookedItem>()
                    .HasOne(e => e.Car)
                    .WithOne(e => e.CarsBookedItem)
                    .HasForeignKey<CarsBookedItem>(e => e.CarId)
                    .IsRequired();

        modelBuilder.Entity<CarDetails>()
                 .HasOne(e => e.Category)
                 .WithOne(e => e.CategoriesCarDetails)
                 .HasForeignKey<CarDetails>(e => e.CategoriesCarId)
                 .IsRequired();

    }

 }