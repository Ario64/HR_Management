﻿using AutoMapper;
using HR_Management.Application.contracts.persistence;
using HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;
using HR_Management.Application.exceptions;
using HR_Management.Application.features.LeaveAllocation.Requests.Commands;
using MediatR;

namespace HR_Management.Application.features.LeaveAllocation.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand,int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto!, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }
}