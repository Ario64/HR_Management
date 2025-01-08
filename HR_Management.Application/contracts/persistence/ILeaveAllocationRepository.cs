using HR_Management.Domain;

namespace HR_Management.Application.contracts.persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetail();
}