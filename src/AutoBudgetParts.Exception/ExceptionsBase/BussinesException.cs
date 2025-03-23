using System.Net;

namespace AutoBudgetParts.Exception.ExceptionsBase;

public class BussinesException(string message) : AutoBudgetPartsExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string>{Message};
    }
}