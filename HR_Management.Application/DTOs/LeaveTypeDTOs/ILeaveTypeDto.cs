namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public interface ILeaveTypeDto
{
    public string? Name { get; set; }
    public int DefaultDay { get; set; }
}