using FluentValidation;
using HR_Management.Application.persistence.contracts;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(r => r.StartDate)
            .NotNull()
            .WithMessage("{PropertyName} must not null be null.");

        RuleFor(r => r.StartDate)
            .LessThan(s => s.EndDate)
            .WithMessage("{PropertyName} must be less than {ComparisonValue}");

        RuleFor(r => r.EndDate)
            .NotNull()
            .WithMessage("{PropertyName} must not null be null.");

        RuleFor(r => r.EndDate)
            .GreaterThan(g => g.StartDate)
            .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

        RuleFor(r => r.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                return !leaveTypeExist;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}