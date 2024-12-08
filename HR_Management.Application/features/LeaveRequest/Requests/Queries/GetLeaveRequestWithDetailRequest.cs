using HR_Management.Application.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestWithDetailRequest : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}