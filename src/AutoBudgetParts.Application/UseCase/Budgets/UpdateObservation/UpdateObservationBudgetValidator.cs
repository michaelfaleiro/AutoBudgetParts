using AutoBudgetParts.Communication.Request.Budgets;
using FluentValidation;

namespace AutoBudgetParts.Application.UseCase.Budgets.UpdateObservation;

public class UpdateObservationBudgetValidator : AbstractValidator<UpdateObservationBudgetRequest>
{
    public UpdateObservationBudgetValidator()
    {
        RuleFor(x => x.Observation)
            .NotEmpty()
            .WithMessage("Observation is required");
    }
    
}