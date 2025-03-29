using AutoBudgetParts.Application.UseCase.Quotes.Create;
using AutoBudgetParts.Communication.Request.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace AutoBudgetParts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateQuote(
        [FromBody] CreateQuoteRequest request,
        [FromServices] CreateQuoteUseCase createQuoteUseCase)
    {
        var response = await createQuoteUseCase.ExecuteAsync(request);
        return Created(string.Empty, response);
    }
    
}