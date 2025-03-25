using AutoBudgetParts.Communication.Response.Budgets;
using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Core.Response;

namespace AutoBudgetParts.Application.UseCase.Budgets.GetAll;

public class GetAllBudgetsUseCase(IBudgetRepository budgetRepository)
{
    public async Task<PagedResponse<BudgetJsonResponse>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var budgets = await budgetRepository.GetAllAsync(pageNumber, pageSize);

        return new PagedResponse<BudgetJsonResponse>
        (
            budgets.Data.Select(x => new BudgetJsonResponse
            (
                x.Id,
                x.ClientName,
                x.CarModel,
                x.CarPlate,
                x.CarVin,
                x.Status,
                x.CreatedAt,
                x.UpdatedAt
            )).ToList(),
            pageNumber,
            pageSize,
            budgets.TotalRecords
        );
    }
    
}