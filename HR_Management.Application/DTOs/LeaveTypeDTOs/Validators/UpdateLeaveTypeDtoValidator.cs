using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;

public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());

        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}