namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public class CreateLeaveTypeDto : ILeaveTypeDto
{
    public string? Name { get; set; }
    public int DefaultDay { get; set; }
}