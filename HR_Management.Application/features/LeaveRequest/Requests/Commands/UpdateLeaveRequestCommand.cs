using HR_Management.Application.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Commands;

public class UpdateLeaveRequestCommand :  IRequest<Unit>
{
    public UpdateLeaveRequestDto? UpdateLeaveRequestDto { get; set; }
}