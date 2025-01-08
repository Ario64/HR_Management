using HR_Management.Application.contracts.persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    #region Context

    private readonly LeaveManagementDbContext _context;

    public LeaveRequestRepository(LeaveManagementDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task<LeaveRequest> GetLeaveRequestWithDetail(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(i => i.LeaveType)
            .FirstOrDefaultAsync(f => f.Id == id);

        return leaveRequest!;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetail()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(i => i.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
    {
        leaveRequest.Approved = approvalStatus;
        _context.Entry(leaveRequest).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }
}