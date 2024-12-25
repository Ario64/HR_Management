
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
        #region Leave Type Mapping

        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();

        #endregion

        #region Leave Request Mapping

        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

        #endregion

        #region Leave Allocation Mapping

        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

        #endregion

    }
}