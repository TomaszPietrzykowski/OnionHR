using MediatR;

namespace OnionHR.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandRequest : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
