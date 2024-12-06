using HR_Management.Application.DTOs.common;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public class LeaveTypeDto : BaseDto
{
    public string? Name { get; set; }
    public int DefaultDay { get; set; }
}