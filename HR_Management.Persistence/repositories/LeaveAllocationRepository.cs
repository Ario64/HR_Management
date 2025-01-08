using HR_Management.Application.contracts.persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    #region Context

    private readonly LeaveManagementDbContext _context;

    public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(i => i.LeaveType)
            .FirstOrDefaultAsync(f => f.Id == id);

        return leaveAllocation!;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetail()
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Include(i => i.LeaveType)
            .ToListAsync();

        return leaveAllocations;

    }
}