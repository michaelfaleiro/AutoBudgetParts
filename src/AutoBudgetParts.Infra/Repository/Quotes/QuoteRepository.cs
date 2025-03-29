using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Quotes;
using AutoBudgetParts.Core.Response;
using AutoBudgetParts.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoBudgetParts.Infra.Repository.Quotes;

public class QuoteRepository(AppDbContext dbContext) : IQuoteRepository
{
    public async Task<Quote?> GetByIdAsync(int id)
    {
        return await dbContext.Quotes
            .Include(x => x.ItemsQuotes)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Quote>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = dbContext.Quotes
            .AsNoTracking()
            .AsQueryable();
        
        var totalRecords = await query.CountAsync();
        
        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResponse<Quote>(data, pageNumber, pageSize, totalRecords);
    }

    public async Task<Quote> CreateAsync(Quote quote)
    {
        await dbContext.Quotes.AddAsync(quote);
        await dbContext.SaveChangesAsync();
        return quote;
    }

    public async Task<Quote> UpdateAsync(Quote quote)
    {
        dbContext.Quotes.Update(quote);
        await dbContext.SaveChangesAsync();
        return quote;
    }
    
}