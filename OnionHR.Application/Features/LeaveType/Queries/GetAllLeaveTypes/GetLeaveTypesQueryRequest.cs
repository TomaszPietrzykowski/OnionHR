using MediatR;

namespace OnionHR.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    //public class GetLeaveTypesQueryRequest : IRequest<List<LeaveTypeDto>>
    //{

    //}
    public record GetLeaveTypesQueryRequest : IRequest<List<LeaveTypeDto>>;
    // can be either record or class (record is unmutable)



}
