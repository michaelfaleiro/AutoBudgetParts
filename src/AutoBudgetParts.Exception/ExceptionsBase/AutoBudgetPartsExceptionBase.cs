using System.Net;

namespace AutoBudgetParts.Exception.ExceptionsBase;

public abstract class AutoBudgetPartsExceptionBase(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();

}