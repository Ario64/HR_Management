using AutoMapper;
using HR_Management.Application.features.LeaveType.Requests.Commands;
using HR_Management.Application.persistence.contracts;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = _mapper.Map<Domain.LeaveType>(request.LeaveTypeDto);
        leaveType = await _leaveTypeRepository.Add(leaveType);
        return leaveType.Id;
    }
}