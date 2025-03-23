namespace AutoBudgetParts.Communication.Request;

public record CreateBudgetRequest(
    string ClientName,
    string CarModel,
    string CarPlate,
    string CarVin
    );