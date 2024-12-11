using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public UpdateLeaveAllocationDto? UpdateLeaveAllocationDto { get; set; }
}