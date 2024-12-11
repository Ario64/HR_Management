using HR_Management.Application.DTOs.common;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public class CreateRequestDto : BaseDto
{
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestedDate { get; set; }
    public string? RequestComment { get; set; }
}