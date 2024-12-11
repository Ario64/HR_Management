using HR_Management.Application.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Commands;

public class UpdateLeaveRequestCommand :  IRequest<Unit>
{
    public int Id { get; set; }
    public UpdateLeaveRequestDto? UpdateLeaveRequestDto { get; set; }
    public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApprovalDto { get; set; }
}