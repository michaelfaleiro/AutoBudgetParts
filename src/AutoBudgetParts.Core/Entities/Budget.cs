namespace AutoBudgetParts.Core.Entities;

public class Budget : Entity
{
    public Budget(string clientName, string carModel, string carPlate, string carVin)
    {
        ClientName = clientName;
        CarModel = carModel;
        CarPlate = carPlate;
        CarVin = carVin;
        ItemsBudget = new List<ItemBudget>();
        CreatedAt = DateTime.UtcNow;
    }

    public string ClientName { get; private set; }
    public string CarModel { get; private set; }
    public string CarPlate { get; private set; }
    public string CarVin { get; private set; }
    public IList<ItemBudget> ItemsBudget { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
   
    public void Update(string clientName, string carModel, string carPlate, string carVin)
    {
        ClientName = clientName;
        CarModel = carModel;
        CarPlate = carPlate;
        CarVin = carVin;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AddItemBudget(ItemBudget itemBudget)
    {
        if (ItemsBudget.Any(x => x.Sku == itemBudget.Sku))
        {
            throw new Exception($"Item with SKU {itemBudget.Sku} already exists in the budget.");
        }
        
        ItemsBudget.Add(itemBudget);
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void RemoveItemBudget(int id)
    {
        var itemBudget = ItemsBudget.FirstOrDefault(x => x.Id == id);
        if (itemBudget is null)
        {
            throw new Exception($"Item with Id {id} does not exist in the budget.");
        }
        
        ItemsBudget.Remove(itemBudget);
        UpdatedAt = DateTime.UtcNow;
    }
}