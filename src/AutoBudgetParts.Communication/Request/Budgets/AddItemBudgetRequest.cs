namespace AutoBudgetParts.Communication.Request.Budgets;
public record AddItemBudgetRequest(
    string Sku,
    string Name,
    string Brand,
    decimal Price,
    int Quantity
);
