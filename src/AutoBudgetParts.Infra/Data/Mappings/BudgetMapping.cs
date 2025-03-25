using AutoBudgetParts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoBudgetParts.Infra.Data.Mappings;

public class BudgetMapping : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budget"); 
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.ClientName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CarModel)
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.CarPlate)
            .HasColumnType("VARCHAR")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.CarVin)
            .HasColumnType("VARCHAR")
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(x=> x.Status)
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();
            
        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt); 
        
        builder.HasMany(x => x.ItemsBudget)
            .WithOne()
            .HasForeignKey("BudgetId")
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasIndex(x => x.Id);
        
        builder.HasIndex(x => x.CarPlate);
        
    }
}