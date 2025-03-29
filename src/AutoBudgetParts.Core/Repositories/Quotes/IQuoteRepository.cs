using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Response;

namespace AutoBudgetParts.Core.Repositories.Quotes;

public interface IQuoteRepository
{
    Task<Quote?> GetByIdAsync(int id);
    Task<PagedResponse<Quote>> GetAllAsync(int pageNumber, int pageSize);
    Task<Quote> CreateAsync(Quote quote);
    Task<Quote> UpdateAsync(Quote quote);
}