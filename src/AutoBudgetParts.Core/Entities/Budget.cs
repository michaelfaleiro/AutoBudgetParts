using AutoBudgetParts.Exception.ExceptionsBase;

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
        Status = "Aberto";
        Observation = string.Empty;
        CreatedAt = DateTime.UtcNow;
    }

    public string ClientName { get; private set; }
    public string CarModel { get; private set; }
    public string CarPlate { get; private set; }
    public string CarVin { get; private set; }
    public IList<ItemBudget> ItemsBudget { get; private set; }
    public string Status { get; private set; }
    public string Observation { get; private set; }
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
        ItemsBudget.Add(itemBudget);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveItemBudget(int id)
    {
        var itemBudget = ItemsBudget.FirstOrDefault(x => x.Id == id)
                        ?? throw new BussinesException($"Item with Id {id} does not exist in the budget.");

        ItemsBudget.Remove(itemBudget);
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateItemBudget(int itemBudgetId, string sku, string name, string brand, decimal price, int quantity)
    {
        var itemBudget = ItemsBudget.FirstOrDefault(x => x.Id == itemBudgetId)
                        ?? throw new BussinesException($"Item with Id {itemBudgetId} does not exist in the budget.");

        itemBudget.Update(sku, name, brand, price, quantity);
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ChangeStatus(string status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ApproveItemBudget(int itemBudgetId)
    {
        var itemBudget = ItemsBudget.FirstOrDefault(x => x.Id == itemBudgetId)
                        ?? throw new BussinesException($"Item with Id {itemBudgetId} does not exist in the budget.");

        itemBudget.Approve();
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateObservation(string observation)
    {
        Observation = observation;
        UpdatedAt = DateTime.UtcNow;
    }
}