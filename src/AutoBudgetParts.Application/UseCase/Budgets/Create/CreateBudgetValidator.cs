using AutoBudgetParts.Communication.Request.Budgets;
using FluentValidation;

namespace AutoBudgetParts.Application.UseCase.Budgets.Create;

public class CreateBudgetValidator : AbstractValidator<CreateBudgetRequest>
{
    public CreateBudgetValidator()
    {
        RuleFor(x => x.ClientName)
            .NotEmpty()
            .WithMessage("ClientName is required");

        RuleFor(x => x.CarModel)
            .NotEmpty()
            .WithMessage("CarModel is required");

        RuleFor(x => x.CarPlate)
            .NotEmpty()
            .WithMessage("CarPlate is required");

        RuleFor(x => x.CarVin)
            .Length(17)
            .When(x => !string.IsNullOrEmpty(x.CarVin))
            .WithMessage("CarVin must have 17 characters");
    }   
    
}