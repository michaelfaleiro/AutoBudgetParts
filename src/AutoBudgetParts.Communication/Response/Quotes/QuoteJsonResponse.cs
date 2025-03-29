namespace AutoBudgetParts.Communication.Response.Quotes;

public record QuoteJsonResponse(
    int Id,
    int BudgetId,
    string Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );