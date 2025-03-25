namespace AutoBudgetParts.Communication.Request.Budgets;

public record UpdateItemBudgetRequest( 
    string Sku,
    string Name,
    string Brand,
    decimal Price,
    int Quantity) : 
    AddItemBudgetRequest( Sku, Name, Brand, Price, Quantity);