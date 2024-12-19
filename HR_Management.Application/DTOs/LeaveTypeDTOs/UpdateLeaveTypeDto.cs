using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public class UpdateLeaveTypeDto  : ILeaveTypeDto
{
    public string? Name { get; set; }
    public int DefaultDay { get; set; }
}