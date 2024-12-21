using FluentValidation;
using HR_Management.Application.persistence.contracts;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
    }
}