using AutoBudgetParts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoBudgetParts.Infra.Data.Mappings;

public class ItemQuoteMapping : IEntityTypeConfiguration<ItemQuote>
{
    public void Configure(EntityTypeBuilder<ItemQuote> builder)
    {
        builder.ToTable("ItemQuote");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Quantity)
            .HasColumnType("INT")
            .IsRequired();
        
        builder.HasIndex(x => x.Id);
    }
}