using HR_Management.Domain;

namespace HR_Management.Application.contracts.persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetail(int id);
    Task<List<LeaveRequest>> GetLeaveRequestListWithDetail();
    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
}