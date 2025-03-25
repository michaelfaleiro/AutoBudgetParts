using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.ChangeStatus;

public class ChangeStatusBudgetUseCase(IBudgetRepository budgetRepository)
{
    public async Task ExecuteAsync(int id, ChangeStatusBudgetRequest request)
    {
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");
        
        budget.ChangeStatus(request.Status);

        await budgetRepository.UpdateAsync(budget);
    }
    
}