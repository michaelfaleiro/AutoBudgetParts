using AutoBudgetParts.Communication.Request.Budgets;
using FluentValidation;

namespace AutoBudgetParts.Application.UseCase.Budgets.ChangeStatus;

public class ChangeStatusBudgetValidator : AbstractValidator<ChangeStatusBudgetRequest>
{
    public ChangeStatusBudgetValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status cannot be empty");
    }
}