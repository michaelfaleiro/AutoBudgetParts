using AutoBudgetParts.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoBudgetParts.Infra.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Budget> Budgets { get; set; } = null!;
    public DbSet<ItemBudget> ItemsBudget { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);    
    }
}