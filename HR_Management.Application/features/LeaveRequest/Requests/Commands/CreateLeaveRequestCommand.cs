using HR_Management.Application.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public LeaveRequestDto? LeaveRequestDto { get; set; }
}