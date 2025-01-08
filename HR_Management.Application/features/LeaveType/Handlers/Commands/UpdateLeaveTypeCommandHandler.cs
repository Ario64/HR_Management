using AutoMapper;
using HR_Management.Application.contracts.persistence;
using HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;
using HR_Management.Application.exceptions;
using HR_Management.Application.features.LeaveType.Requests.Commands;
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
        var validator = new UpdateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto!, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto!.Id);
        _mapper.Map(request.LeaveTypeDto, leaveType);
        await _leaveTypeRepository.Update(leaveType);
        return Unit.Value;
    }
}