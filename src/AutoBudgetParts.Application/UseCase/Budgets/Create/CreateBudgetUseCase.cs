using AutoBudgetParts.Communication.Request;
using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Communication.Response.Budgets;
using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Budgets;

namespace AutoBudgetParts.Application.UseCase.Budgets.Create;

public class CreateBudgetUseCase(IBudgetRepository budgetRepository)
{

    public async Task<ResponseJson<BudgetJsonResponse>> ExecuteAsync(CreateBudgetRequest request)
    {
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
                budget.CreatedAt,
                budget.UpdatedAt
            )
        );
    }
}