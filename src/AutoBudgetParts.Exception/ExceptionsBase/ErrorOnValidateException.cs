using System.Net;

namespace AutoBudgetParts.Exception.ExceptionsBase;

public class ErrorOnValidateException(IList<string> messages) : AutoBudgetPartsExceptionBase(string.Empty)
{
   public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return messages;
    }
}