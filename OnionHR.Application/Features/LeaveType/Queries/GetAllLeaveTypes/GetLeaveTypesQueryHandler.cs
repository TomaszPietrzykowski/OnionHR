using AutoMapper;
using MediatR;
using OnionHR.Application.Contracts.Logging;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQueryRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            _logger.LogInformation("Leave Types retrieved successfully");
            return data;

        }
    }
}
