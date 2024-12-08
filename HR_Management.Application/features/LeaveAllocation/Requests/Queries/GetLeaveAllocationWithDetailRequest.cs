using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Requests.Queries;

public class GetLeaveAllocationWithDetailRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}