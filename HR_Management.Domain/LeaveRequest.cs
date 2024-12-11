using HR_Management.Domain.common;
using System;

namespace HR_Management.Domain;

public class LeaveRequest : BaseDomainEntity
{
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestedDate { get; set; }
    public string? RequestComment { get; set; }
    public DateTime? ActionedDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public LeaveType? LeaveType { get; set; }
}