
using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using HR_Management.Application.DTOs.LeaveRequestDTOs;
using HR_Management.Application.DTOs.LeaveTypeDTOs;
using HR_Management.Domain;

namespace HR_Management.Application.profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
    }
}