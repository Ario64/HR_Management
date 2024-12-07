using HR_Management.Application.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Requests.Queries;

public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}