﻿using HR_Management.Application.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.features.LeaveType.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeDto? CreateLeaveTypeDto { get; set; }
}