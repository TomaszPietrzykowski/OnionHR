using OnionHR.Domain.Common;

namespace OnionHR.Domain;

public class LeaveRequest : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType? LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled {  get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;

}