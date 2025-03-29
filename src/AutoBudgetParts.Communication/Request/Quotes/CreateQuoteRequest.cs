namespace AutoBudgetParts.Communication.Request.Quotes;

public record CreateQuoteRequest(
    int BudgetId,
    string Status);
