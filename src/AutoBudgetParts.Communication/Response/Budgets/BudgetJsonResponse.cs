namespace AutoBudgetParts.Communication.Response.Budgets;

public record BudgetJsonResponse(
    int Id,
    string ClientName,
    string CarModel,
    string CarPlate,
    string CarVin,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
