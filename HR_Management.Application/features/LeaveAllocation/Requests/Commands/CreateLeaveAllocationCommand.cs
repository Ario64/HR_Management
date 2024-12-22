using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public CreateLeaveAllocationDto? CreateLeaveAllocationDto { get; set; }
}