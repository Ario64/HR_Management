using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());
    }
}