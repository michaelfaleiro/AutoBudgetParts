using AutoBudgetParts.Communication.Response.Quotes.ItemsQuotes;

namespace AutoBudgetParts.Communication.Response.Quotes;

public record QuoteFullJsonReponse(
    int Id,
    int QuoteId,
    string Status,
    IEnumerable<ItemQuoteJsonResponse> ItemsQuotes,
    DateTime CreatedAt,
    DateTime? UpdatedAt);