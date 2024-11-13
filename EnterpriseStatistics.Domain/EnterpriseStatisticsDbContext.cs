using EnterpriseStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseStatistics.Domain;

public class EnterpriseStatisticsDbContext(DbContextOptions<EnterpriseStatisticsDbContext> options) : DbContext(options)
{
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Supply> Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enterprise>()
            .HasKey(e => e.MainStateRegistrationNumber);

        modelBuilder.Entity<Enterprise>()
            .Property(e => e.MainStateRegistrationNumber)
            .ValueGeneratedNever();

        modelBuilder.Entity<Enterprise>()
            .Property(e => e.IndustryType)
            .HasConversion(type => type.ToString(), type => (IndustryTypes)Enum.Parse(typeof(IndustryTypes), type));

        modelBuilder.Entity<Enterprise>()
            .Property(e => e.OwnershipForm)
            .HasConversion(type => type.ToString(), type => (OwnershipForms)Enum.Parse(typeof(OwnershipForms), type));

        modelBuilder.Entity<Supplier>()
            .HasKey(s => s.Id);
        
        modelBuilder.Entity<Supply>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Supply>()
            .HasOne(s => s.Supplier)
            .WithMany()
            .HasForeignKey("supplier_id")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Supply>()
            .HasOne(s => s.Enterprise)
            .WithMany()
            .HasForeignKey("enterprise_id")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.ToSnakeCase();
    }
}

