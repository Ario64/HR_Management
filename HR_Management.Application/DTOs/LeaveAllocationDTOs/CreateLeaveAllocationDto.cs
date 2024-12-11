using HR_Management.Application.DTOs.common;
using HR_Management.Application.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs;

public class CreateLeaveAllocationDto : BaseDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}