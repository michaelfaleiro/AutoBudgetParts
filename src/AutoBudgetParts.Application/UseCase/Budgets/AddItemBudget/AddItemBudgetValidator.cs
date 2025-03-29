using AutoBudgetParts.Communication.Request.Budgets;
using FluentValidation;

namespace AutoBudgetParts.Application.UseCase.Budgets.AddItemBudget;

public class AddItemBudgetValidator : AbstractValidator<AddItemBudgetRequest>
{
    public AddItemBudgetValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku is required");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        
        RuleFor(x => x.Brand)
            .NotEmpty()
            .WithMessage("Brand is required");
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
        
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
    
}