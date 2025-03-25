using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.ApprovedItemBudget;

public class ApprovedItemBudgetUseCase(IBudgetRepository budgetRepository)
{
    public async Task ExecuteAsync(int id, int itemBudgetId)
    {
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");
        
        budget.ApproveItemBudget(itemBudgetId);

        await budgetRepository.UpdateAsync(budget);
    }
    
}