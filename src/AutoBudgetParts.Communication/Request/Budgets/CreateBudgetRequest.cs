namespace AutoBudgetParts.Communication.Request.Budgets;

public record CreateBudgetRequest(
    string ClientName,
    string CarModel,
    string CarPlate,
    string CarVin
    );