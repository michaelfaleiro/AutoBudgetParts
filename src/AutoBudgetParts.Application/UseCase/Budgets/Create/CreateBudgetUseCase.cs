using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Budgets;
using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Communication.Response.Budgets;
using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Budgets;

namespace AutoBudgetParts.Application.UseCase.Budgets.Create;

public class CreateBudgetUseCase(IBudgetRepository budgetRepository) : ValidateBase<CreateBudgetRequest>
{

    public async Task<ResponseJson<BudgetJsonResponse>> ExecuteAsync(CreateBudgetRequest request)
    {
        Validate(request, new CreateBudgetValidator());
        
        var budget = new Budget(
            request.ClientName, request.CarModel, request.CarPlate, request.CarVin);
       
        await budgetRepository.CreateAsync(budget);

        return new ResponseJson<BudgetJsonResponse>(
            new BudgetJsonResponse(
                budget.Id,
                budget.ClientName,
                budget.CarModel,
                budget.CarPlate,
                budget.CarVin,
                budget.Status,
                budget.CreatedAt,
                budget.UpdatedAt
            )
        );
    }
}