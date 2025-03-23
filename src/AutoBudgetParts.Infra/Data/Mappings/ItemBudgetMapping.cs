using AutoBudgetParts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoBudgetParts.Infra.Data.Mappings;

public class ItemBudgetMapping : IEntityTypeConfiguration<ItemBudget>
{
    public void Configure(EntityTypeBuilder<ItemBudget> builder)
    {
        builder.ToTable("ItemBudget");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Sku)
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Brand)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .HasColumnType("DECIMAL(10,2)")
            .IsRequired();
        
        builder.Property(x => x.Quantity)
            .HasColumnType("INT")
            .IsRequired();
        
        builder.Property(x => x.Approved)
            .HasColumnType("BOOLEAN")
            .IsRequired();

        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);
        
        builder.HasIndex(x => x.Id);
        
    }
}