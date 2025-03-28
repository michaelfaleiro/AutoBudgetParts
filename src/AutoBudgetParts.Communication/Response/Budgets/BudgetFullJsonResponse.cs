using AutoBudgetParts.Communication.Response.ItemsBudgets;

namespace AutoBudgetParts.Communication.Response.Budgets;

public record BudgetFullJsonResponse(
    int Id,
    string ClientName,
    string CarModel,
    string CarPlate,
    string CarVin,
    IEnumerable<ItemBudgetJsonResponse> Items,
    string Status,
    string Observation,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
