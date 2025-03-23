using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoBudgetParts.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AutoBudgetPartsExceptionBase)
        {
            var autoBudgetPartsExceptionBase = (AutoBudgetPartsExceptionBase)context.Exception;

            context.HttpContext.Response.StatusCode = (int)autoBudgetPartsExceptionBase.GetStatusCode();

            var responseJson = new ResponseErrorJson(autoBudgetPartsExceptionBase.GetErrorMessages().ToList());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var list = new List<string> { "Internal Server Error" };

            var responseJson = new ResponseErrorJson(list);

            context.Result = new ObjectResult(responseJson);
        }
    }

}