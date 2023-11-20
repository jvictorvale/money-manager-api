using System.Reflection;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Extensions;

namespace MoneyManager.Infra.Data.Context;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Revenue> Revenues { get; set; } = null!;
    public async Task<bool> Commit() => await SaveChangesAsync() > 0;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        ApplyConfigurations(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyTrackingChanges();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void ApplyTrackingChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is ITracking && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            ((ITracking)entityEntry.Entity).UpdatedAt = DateTime.Now;
            
            if (entityEntry.State != EntityState.Added)
                continue;

            ((ITracking)entityEntry.Entity).CreatedAt = DateTime.Now;
        }
    }
    
    private static void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.ApplyEntityConfiguration();
        modelBuilder.ApplyTrackingConfiguration();
    }
}