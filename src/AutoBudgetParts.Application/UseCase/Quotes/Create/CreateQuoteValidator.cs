using AutoBudgetParts.Communication.Request.Quotes;
using FluentValidation;

namespace AutoBudgetParts.Application.UseCase.Quotes.Create;

public class CreateQuoteValidator : AbstractValidator<CreateQuoteRequest>
{
    public CreateQuoteValidator()
    {
        RuleFor(x => x.BudgetId)
            .NotEmpty()
            .WithMessage("BudgetId is required");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required")
            .MaximumLength(30)
            .WithMessage("Status must be less than 30 characters");
        
    }
    
}