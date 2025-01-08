using AutoMapper;
using HR_Management.Application.contracts.persistence;
using HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;
using HR_Management.Application.features.LeaveRequest.Requests.Commands;
using HR_Management.Application.infrastructure;
using HR_Management.Application.models;
using HR_Management.Application.responses;
using MediatR;

namespace HR_Management.Application.features.LeaveRequest.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto!, cancellationToken);

        if (validationResult.IsValid == false)
        {
            //throw new ValidationException(validationResult);
            response.Success = false;
            response.Message = "The operation failed";
            response.Errors = validationResult.Errors.Select(s => s.ErrorMessage).ToList();
        }

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
        response.Success = true;
        response.Message = "The operation succeeded";
        response.Id = leaveRequest.Id;

        var email = new Email()
        {
            To = "gh.shahrokhi9@gmail.com",
            Subject = "Leave Request Submitted",
            Body = $"your leave Request from {request.CreateLeaveRequestDto!.StartDate} to {request.CreateLeaveRequestDto!.EndDate} has been submitted."
        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception)
        {
          //log
        }

        return response;
    }
}