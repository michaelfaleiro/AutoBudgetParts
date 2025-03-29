namespace AutoBudgetParts.Core.Entities;

public class ItemQuote : Entity
{
    public ItemQuote(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    
    public void Update(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
}