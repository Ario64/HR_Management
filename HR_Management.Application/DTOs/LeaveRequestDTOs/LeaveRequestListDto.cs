using HR_Management.Application.DTOs.common;
using HR_Management.Application.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public class LeaveRequestListDto :BaseDto
{
    public DateTime RequestedDate { get; set; }
    public bool? Approved { get; set; }

    public LeaveTypeDto? LeaveTypeDto { get; set; }
}