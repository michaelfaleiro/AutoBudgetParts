using AutoBudgetParts.Application.UseCase.Budgets.Create;
using AutoBudgetParts.Application.UseCase.Budgets.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBudgetParts.Application.Services.Budgets;

public static class BudgetService
{
    public static IServiceCollection AddBudgetService(this IServiceCollection services)
    {
        services.AddScoped<CreateBudgetUseCase>();
        services.AddScoped<GetBudgetByIdUseCase>();
        return services;
    }
}