﻿using FluentValidation;
using HR_Management.Application.persistence.contracts;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));

        RuleFor(r => r.Id)
            .NotNull()
            .WithMessage("{PropertyName is required.}");
    }
}