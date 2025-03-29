namespace AutoBudgetParts.Core.Entities;

public class Quote : Entity
{
    public Quote(int budgetId,string status)
    {
        BudgetId = budgetId;
        Status = status;
        CreateAt = DateTime.UtcNow;
        ItemsQuotes = new List<ItemQuote>();
    }

    public int BudgetId { get; private set; }
    public string Status { get; private set; }
    public IList<ItemQuote> ItemsQuotes { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    
    public void AddItemQuote(ItemQuote item)
    {
        var itemQuote = new ItemQuote(item.Name, item.Quantity);
        ItemsQuotes.Add(itemQuote);
    }
    
}