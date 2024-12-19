using FluentValidation;
using HR_Management.Application.persistence.contracts;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}