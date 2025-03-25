using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.RemoveItemBudget;

public class RemoveItemBudgetUseCase(IBudgetRepository budgetRepository)
{
    public async Task ExecuteAsync(int id, int itemId)
    {
        var budget = await budgetRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException("Budget not found");

        budget.RemoveItemBudget(itemId);

        await budgetRepository.UpdateAsync(budget);
    }

}
