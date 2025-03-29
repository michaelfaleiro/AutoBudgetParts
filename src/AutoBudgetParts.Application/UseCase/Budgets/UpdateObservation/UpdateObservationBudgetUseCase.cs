using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.UpdateObservation;

public class UpdateObservationBudgetUseCase(IBudgetRepository budgetRepository) : ValidateBase<UpdateObservationBudgetRequest>
{
    public async Task ExecuteAsync(int id, UpdateObservationBudgetRequest request)
    {
        Validate(request, new UpdateObservationBudgetValidator());
        
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");
        
        budget.UpdateObservation(request.Observation);
        await budgetRepository.UpdateAsync(budget);
    }
    
}