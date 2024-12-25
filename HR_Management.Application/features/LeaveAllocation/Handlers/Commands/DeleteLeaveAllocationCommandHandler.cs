using HR_Management.Application.exceptions;
using HR_Management.Application.features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.persistence.contracts;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Handlers.Commands;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.Get(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);
        //if (leaveAllocation == null)
        //{
        //    throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);
        //}

        await _leaveAllocationRepository.Delete(leaveAllocation);
        return Unit.Value;
    }
}