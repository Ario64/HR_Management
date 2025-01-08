using HR_Management.Application.contracts.persistence;
using HR_Management.Application.exceptions;
using HR_Management.Application.features.LeaveType.Requests.Commands;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Handlers.Commands;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
        }

        await _leaveTypeRepository.Delete(leaveType);
        return Unit.Value;
    }
}