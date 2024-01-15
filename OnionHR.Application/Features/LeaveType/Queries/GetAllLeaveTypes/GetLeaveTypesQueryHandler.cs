using AutoMapper;
using MediatR;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQueryRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
        {
            // query db
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // convert to dto
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // return list
            return data;

        }
    }
}
