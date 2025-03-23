using AutoBudgetParts.Application.UseCase.Budgets.Create;
using AutoBudgetParts.Application.UseCase.Budgets.GetById;
using AutoBudgetParts.Communication.Request;
using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Communication.Response.Budgets;
using Microsoft.AspNetCore.Mvc;

namespace AutoBudgetParts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Budgets : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJson<BudgetJsonResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBudget(
        [FromBody] CreateBudgetRequest request,
        [FromServices] CreateBudgetUseCase createBudgetUseCase)
    {
        var response = await createBudgetUseCase.ExecuteAsync(request);
        return Created(string.Empty, response);
        
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ResponseJson<BudgetFullJsonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBudgetById(
        int id,
        [FromServices] GetBudgetByIdUseCase getBudgetByIdUseCase)
    {
        var response = await getBudgetByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }
    
}