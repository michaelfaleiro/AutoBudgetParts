using AutoBudgetParts.Application.UseCase.Budgets.AddItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.ApprovedItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.ChangeStatus;
using AutoBudgetParts.Application.UseCase.Budgets.Create;
using AutoBudgetParts.Application.UseCase.Budgets.GetAll;
using AutoBudgetParts.Application.UseCase.Budgets.GetById;
using AutoBudgetParts.Application.UseCase.Budgets.RemoveItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.UpdateItemBudget;
using AutoBudgetParts.Application.UseCase.Budgets.UpdateObservation;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBudgetParts.Application.Services.Budgets;

public static class BudgetService
{
    public static IServiceCollection AddBudgetService(this IServiceCollection services)
    {
        services.AddScoped<CreateBudgetUseCase>();
        services.AddScoped<GetBudgetByIdUseCase>();
        services.AddScoped<GetAllBudgetsUseCase>();
        services.AddScoped<AddItemBudgetUseCase>();
        services.AddScoped<UpdateItemBudgetUseCase>();
        services.AddScoped<RemoveItemBudgetUseCase>();
        services.AddScoped<ChangeStatusBudgetUseCase>();
        services.AddScoped<ApprovedItemBudgetUseCase>();
        services.AddScoped<UpdateObservationBudgetUseCase>();

        return services;
    }
}