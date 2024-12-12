using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Requests.Commands;

public class DeleteLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}