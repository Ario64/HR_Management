using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using HR_Management.Domain;

namespace HR_Management.Application.persistence.contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetail();
}