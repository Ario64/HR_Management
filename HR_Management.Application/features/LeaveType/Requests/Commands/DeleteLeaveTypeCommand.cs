using HR_Management.Application.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}