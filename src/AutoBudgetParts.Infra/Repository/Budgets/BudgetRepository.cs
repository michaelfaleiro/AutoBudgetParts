using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Core.Response;
using AutoBudgetParts.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoBudgetParts.Infra.Repository.Budgets;

public class BudgetRepository(AppDbContext dbContext) : IBudgetRepository
{
    public async Task<Budget?> GetByIdAsync(int id)
    {
        return await dbContext.Budgets
            .Include(x => x.ItemsBudget)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Budget>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = dbContext.Budgets
            .AsNoTracking()
            .AsQueryable();
        
        var totalRecords = await query.CountAsync();
        
        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResponse<Budget>(data, pageNumber, pageSize, totalRecords);
    }

    public async Task<Budget> CreateAsync(Budget budget)
    {
        await dbContext.Budgets.AddAsync(budget);
        await dbContext.SaveChangesAsync();
        return budget;
    }

    public async Task<Budget> UpdateAsync(Budget budget)
    {
        dbContext.Budgets.Update(budget);
        await dbContext.SaveChangesAsync();
        return budget;
    }
}