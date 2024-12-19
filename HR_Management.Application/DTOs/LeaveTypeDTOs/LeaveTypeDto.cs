using HR_Management.Application.DTOs.common;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public class LeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string? Name { get; set; }
    public int DefaultDay { get; set; }
}