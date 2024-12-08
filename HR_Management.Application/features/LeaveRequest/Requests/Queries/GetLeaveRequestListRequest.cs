using HR_Management.Application.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
{
    
}