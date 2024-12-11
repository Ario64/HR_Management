using HR_Management.Application.DTOs.common;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool? Approved { get; set; }
}