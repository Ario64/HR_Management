namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public interface ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
}