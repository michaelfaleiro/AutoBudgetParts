using System.Net;

namespace AutoBudgetParts.Exception.ExceptionsBase;

public class NotFoundException(string message) : AutoBudgetPartsExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string>{Message};   
    }
}