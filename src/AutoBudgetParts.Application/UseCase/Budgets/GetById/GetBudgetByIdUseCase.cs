using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Communication.Response.Budgets;
using AutoBudgetParts.Communication.Response.ItemsBudgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Exception.ExceptionsBase;

namespace AutoBudgetParts.Application.UseCase.Budgets.GetById;

public class GetBudgetByIdUseCase(IBudgetRepository budgetRepository)
{
    public async Task<ResponseJson<BudgetFullJsonResponse>> ExecuteAsync(int id)
    {
        var budget = await budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");

        return new ResponseJson<BudgetFullJsonResponse>(
            new BudgetFullJsonResponse(
                budget.Id,
                budget.ClientName,
                budget.CarModel,
                budget.CarPlate,
                budget.CarVin,
                budget.ItemsBudget.Select(item => new ItemBudgetJsonResponse(
                    item.Id,
                    item.Sku,
                    item.Name,
                    item.Brand,
                    item.Price,
                    item.Quantity,
                    item.Approved,
                    item.CreatedAt,
                    item.UpdatedAt
                )).ToList(),
                budget.CreatedAt,
                budget.UpdatedAt
            )
        );
    }
}