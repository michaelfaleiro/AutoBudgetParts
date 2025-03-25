namespace AutoBudgetParts.Communication.Response.Budgets;

public record BudgetJsonResponse(
    int Id,
    string ClientName,
    string CarModel,
    string CarPlate,
    string CarVin,
    string Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
