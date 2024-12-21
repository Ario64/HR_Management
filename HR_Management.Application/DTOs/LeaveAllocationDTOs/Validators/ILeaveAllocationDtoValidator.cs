using FluentValidation;
using HR_Management.Application.persistence.contracts;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(r => r.NumberOfDate)
            .NotNull()
            .WithMessage("{PropertyName} must not null be null.");

        RuleFor(r => r.NumberOfDate)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must not null be greater than {ComparisonValue}.");

        RuleFor(r => r.Period)
            .NotNull()
            .WithMessage("{PropertyName} must not null be null.");

        RuleFor(r => r.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(r => r.LeaveTypeId)
            .NotNull()
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeId = await _leaveTypeRepository.Exist(id);
                return !leaveTypeId;
            })
            .WithMessage("{PropertyName} does not exist.");
    }
}