using HR_Management.Application.DTOs.common;
using HR_Management.Application.DTOs.LeaveTypeDTOs;
using HR_Management.Domain;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs;

public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }

    public LeaveTypeDto? LeaveTypeDto { get; set; }
}