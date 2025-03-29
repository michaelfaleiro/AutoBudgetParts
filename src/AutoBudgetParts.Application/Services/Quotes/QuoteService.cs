using AutoBudgetParts.Application.UseCase.Quotes.Create;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBudgetParts.Application.Services.Quotes;

public static class QuoteService
{
    public static IServiceCollection AddQuoteService(this IServiceCollection services)
    {
        services.AddScoped<CreateQuoteUseCase>();
        
        return services;
    }
}