using HR_Management.Domain.common;

namespace HR_Management.Domain;

public class LeaveAllocation : BaseDomainEntity
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }

    public LeaveType? LeaveType { get; set; }

}