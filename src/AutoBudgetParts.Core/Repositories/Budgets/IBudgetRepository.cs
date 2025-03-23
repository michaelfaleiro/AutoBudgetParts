using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Response;

namespace AutoBudgetParts.Core.Repositories.Budgets;

public interface IBudgetRepository
{
    Task<Budget?> GetByIdAsync(int id);
    Task<PagedResponse<Budget>> GetAllAsync(int pageNumber, int pageSize);
    Task<Budget> CreateAsync(Budget budget);
    Task<Budget> UpdateAsync(Budget budget);
}