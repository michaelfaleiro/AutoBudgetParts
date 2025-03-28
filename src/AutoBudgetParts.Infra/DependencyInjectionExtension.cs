using AutoBudgetParts.Core.Repositories.Budgets;
using AutoBudgetParts.Core.Repositories.Quotes;
using AutoBudgetParts.Infra.Repository.Budgets;
using AutoBudgetParts.Infra.Repository.Quotes;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBudgetParts.Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IBudgetRepository, BudgetRepository>();
        services.AddScoped<IQuoteRepository, QuoteRepository>();
    }
}