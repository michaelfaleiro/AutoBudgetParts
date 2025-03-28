using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.AddItemBudget;

public class AddItemBudgetUseCase(IBudgetRepository budgetRepository) : ValidateBase<AddItemBudgetRequest>
{
    public async Task ExecuteAsync(int id, AddItemBudgetRequest request)
    {
        Validate(request, new AddItemBudgetValidator());
        
        var budget = await budgetRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException("Budget not found");

        var itemBudget = new ItemBudget(request.Sku, request.Name, request.Brand, request.Price, request.Quantity);
        budget.AddItemBudget(itemBudget);

        await budgetRepository.UpdateAsync(budget);
    }
}
