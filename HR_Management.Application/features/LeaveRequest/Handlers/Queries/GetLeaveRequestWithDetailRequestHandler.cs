using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequestDTOs;
using HR_Management.Application.features.LeaveRequest.Requests.Queries;
using HR_Management.Application.persistence.contracts;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestWithDetailRequestHandler : IRequestHandler<GetLeaveRequestWithDetailRequest, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestWithDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestWithDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetail(request.Id);
        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}