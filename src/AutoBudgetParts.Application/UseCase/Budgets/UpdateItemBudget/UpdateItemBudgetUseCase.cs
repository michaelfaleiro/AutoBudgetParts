using AutoBudgetParts.Application.UseCase.Budgets.AddItemBudget;
using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.UpdateItemBudget;

public class UpdateItemBudgetUseCase(IBudgetRepository budgetRepository) : ValidateBase<UpdateItemBudgetRequest>
{
    public async Task ExecuteAsync(int id, int itemBudgetId, UpdateItemBudgetRequest request)
    {
        Validate(request, new AddItemBudgetValidator());
        
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");
        
        budget.UpdateItemBudget(itemBudgetId, request.Sku, request.Name, request.Brand, request.Price, request.Quantity);

        await budgetRepository.UpdateAsync(budget);
    }
    
}