using HR_Management.Application.DTOs.LeaveRequestDTOs;
using HR_Management.Application.responses;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveRequestDto? CreateLeaveRequestDto { get; set; }
}