using AutoBudgetParts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoBudgetParts.Infra.Data.Mappings;

public class QuoteMapping : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.ToTable("Quotes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.BudgetId)
            .IsRequired()
            .HasColumnType("INT");
        
        builder.Property(x => x.Status)
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.CreateAt);
        
        builder.Property(x => x.UpdateAt);
        
        builder.HasMany(x => x.ItemsQuotes)
            .WithOne()
            .HasForeignKey("QuoteId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(x => x.Id);
        
        builder.HasIndex(x => x.BudgetId);
    }
}