namespace AutoBudgetParts.Core.Entities;

public class ItemBudget : Entity
{
    public ItemBudget(string sku, string name, string brand, decimal price, int quantity)
    {
        Sku = sku;
        Name = name;
        Brand = brand;
        Price = price;
        Quantity = quantity;
        Approved = true;
        CreatedAt = DateTime.UtcNow;
    }
    
    public string Sku { get; private set; }
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public bool Approved { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    public void Update(string sku, string name, string brand, decimal price, int quantity)
    {
        Sku = sku;
        Name = name;
        Brand = brand;
        Price = price;
        Quantity = quantity;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Approve()
    {
        Approved = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Disapprove()
    {
        Approved = false;
        UpdatedAt = DateTime.UtcNow;
    }
}