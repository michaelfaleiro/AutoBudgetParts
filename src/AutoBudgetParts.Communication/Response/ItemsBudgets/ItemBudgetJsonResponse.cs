namespace AutoBudgetParts.Communication.Response.ItemsBudgets;

public record ItemBudgetJsonResponse(
    int Id,
    string Sku,
    string Name,
    string Brand,
    decimal Price,
    int Quantity,
    bool Approved,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );