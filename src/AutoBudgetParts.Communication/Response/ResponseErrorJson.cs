namespace AutoBudgetParts.Communication.Response;

public class ResponseErrorJson(IList<string> errors)
{
    public IList<string> Errors { get; set; } = errors;
}