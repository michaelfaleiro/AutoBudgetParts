using AutoBudgetParts.Application.UseCase.Budgets.AddItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.ApprovedItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.ChangeStatus;
using AutoBudgetParts.Application.UseCase.Budgets.Create;
using AutoBudgetParts.Application.UseCase.Budgets.GetAll;
using AutoBudgetParts.Application.UseCase.Budgets.GetById;
using AutoBudgetParts.Application.UseCase.Budgets.RemoveItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.UpdateItemBudget;
using AutoBudgetParts.Communication.Request;
using AutoBudgetParts.Communication.Request.Budgets;
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
    
    [HttpGet]
    [ProducesResponseType(typeof(ResponseJson<PagedResponse<BudgetJsonResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBudgets(
        [FromServices] GetAllBudgetsUseCase getAllBudgetsUseCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize
        )
    {
        var response = await getAllBudgetsUseCase.ExecuteAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ResponseJson<BudgetFullJsonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBudgetById(
        int id,
        [FromServices] GetBudgetByIdUseCase getBudgetByIdUseCase)
    {
        var response = await getBudgetByIdUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost("{id:int}/items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddItemBudget(
        int id,
        [FromBody] AddItemBudgetRequest request,
        [FromServices] AddItemBudgetUseCase addItemBudgetUseCase)
    {
        await addItemBudgetUseCase.ExecuteAsync(id, request);
        return NoContent();
    }
    
    [HttpPatch("{id:int}/items/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItemBudget(
        int id,
        int itemId,
        [FromBody] UpdateItemBudgetRequest request,
        [FromServices] UpdateItemBudgetUseCase updateItemBudgetUseCase)
    {
        await updateItemBudgetUseCase.ExecuteAsync(id, itemId, request);
        return NoContent();
    }

    [HttpDelete("{id:int}/items/{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveItemBudget(
        int id,
        int itemId,
        [FromServices] RemoveItemBudgetUseCase removeItemBudgetUseCase)
    {
        await removeItemBudgetUseCase.ExecuteAsync(id, itemId);
        return NoContent();
    }
    
    [HttpPost("{id:int}/items/{itemId:int}/approved")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ApprovedItemBudget(
        int id,
        int itemId,
        [FromServices] ApprovedItemBudgetUseCase approvedItemBudgetUseCase)
    {
        await approvedItemBudgetUseCase.ExecuteAsync(id, itemId);
        return NoContent();
    }
    
    [HttpPatch("{id:int}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeStatusBudget(
        int id,
        [FromBody] ChangeStatusBudgetRequest request,
        [FromServices] ChangeStatusBudgetUseCase changeStatusBudgetUseCase)
    {
        await changeStatusBudgetUseCase.ExecuteAsync(id, request);
        return NoContent();
    }

}