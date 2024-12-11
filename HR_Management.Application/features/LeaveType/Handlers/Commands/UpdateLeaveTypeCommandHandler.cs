using AutoMapper;
using HR_Management.Application.features.LeaveType.Requests.Commands;
using HR_Management.Application.persistence.contracts;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto!.Id);
        leaveType = _mapper.Map(leaveType, Domain.LeaveType);
        await _leaveTypeRepository.Update(leaveType);
        return Unit.Value;
    }
}