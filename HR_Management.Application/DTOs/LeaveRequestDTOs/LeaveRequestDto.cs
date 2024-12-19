using HR_Management.Application.DTOs.common;
using HR_Management.Application.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public class LeaveRequestDto : BaseDto , ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestedDate { get; set; }
    public string? RequestComment { get; set; }
    public DateTime? ActionedDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public LeaveTypeDto? LeaveTypeDto { get; set; }
}