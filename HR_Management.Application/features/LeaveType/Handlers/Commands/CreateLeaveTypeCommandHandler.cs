using AutoMapper;
using HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;
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
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto!, cancellationToken);
        if (validationResult.IsValid == false)
            throw new Exception();

        var leaveType = _mapper.Map<Domain.LeaveType>(request.CreateLeaveTypeDto);
        leaveType = await _leaveTypeRepository.Add(leaveType);
        return leaveType.Id;
    }
}