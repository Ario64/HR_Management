using HR_Management.Application.DTOs.common;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs;

public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}