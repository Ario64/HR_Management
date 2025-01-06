using HR_Management.Application.persistence.contracts;
using HR_Management.Domain;

namespace HR_Management.Persistence.repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    #region Context

    private readonly LeaveManagementDbContext _context;

    public LeaveTypeRepository(LeaveManagementDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}