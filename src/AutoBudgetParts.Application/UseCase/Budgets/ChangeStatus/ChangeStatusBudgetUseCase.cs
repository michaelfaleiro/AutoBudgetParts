using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.ChangeStatus;

public class ChangeStatusBudgetUseCase(IBudgetRepository budgetRepository) : ValidateBase<ChangeStatusBudgetRequest>
{
    public async Task ExecuteAsync(int id, ChangeStatusBudgetRequest request)
    {
        Validate(request, new ChangeStatusBudgetValidator());
        
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");
        
        budget.ChangeStatus(request.Status);

        await budgetRepository.UpdateAsync(budget);
    }
    
}