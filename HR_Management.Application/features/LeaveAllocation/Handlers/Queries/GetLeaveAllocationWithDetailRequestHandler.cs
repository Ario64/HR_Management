using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using HR_Management.Application.features.LeaveAllocation.Requests.Queries;
using HR_Management.Application.persistence.contracts;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationWithDetailRequestHandler : IRequestHandler<GetLeaveAllocationWithDetailRequest, LeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationWithDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationWithDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetail(request.Id);
        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}