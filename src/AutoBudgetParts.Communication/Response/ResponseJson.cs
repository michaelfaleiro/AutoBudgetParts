namespace AutoBudgetParts.Communication.Response;

public class ResponseJson<TData>(TData data)
{
    public TData Data { get; set; } = data;
}