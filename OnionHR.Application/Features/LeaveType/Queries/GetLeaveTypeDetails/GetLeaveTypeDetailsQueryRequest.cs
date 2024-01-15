using MediatR;

namespace OnionHR.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDto>;
}
