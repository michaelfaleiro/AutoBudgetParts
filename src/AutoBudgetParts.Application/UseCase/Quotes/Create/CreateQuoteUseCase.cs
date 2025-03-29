using AutoBudgetParts.Application.Validator;
using AutoBudgetParts.Communication.Request.Quotes;
using AutoBudgetParts.Communication.Response;
using AutoBudgetParts.Communication.Response.Quotes;
using AutoBudgetParts.Core.Entities;
using AutoBudgetParts.Core.Repositories.Quotes;

namespace AutoBudgetParts.Application.UseCase.Quotes.Create;

public class CreateQuoteUseCase(IQuoteRepository quoteRepository) : ValidateBase<CreateQuoteRequest>
{
    public async Task<ResponseJson<QuoteJsonResponse>>ExecuteAsync(CreateQuoteRequest request) 
    {
        
        Validate(request, new CreateQuoteValidator());
        
        var quote = new Quote(request.BudgetId, request.Status);
        
        await quoteRepository.CreateAsync(quote);

        return new ResponseJson<QuoteJsonResponse>(
            
            new QuoteJsonResponse(
                quote.Id,
                quote.BudgetId,
                quote.Status,
                quote.CreateAt,
                quote.UpdateAt
            )
        );
    }
    
}