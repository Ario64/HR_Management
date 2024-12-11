using HR_Management.Application.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public LeaveTypeDto? LeaveTypeDto { get; set; }
}