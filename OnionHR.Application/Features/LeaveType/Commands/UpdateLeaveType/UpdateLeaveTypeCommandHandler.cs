using AutoMapper;
using MediatR;
using OnionHR.Application.Contracts.Logging;
using OnionHR.Application.Contracts.Persistance;
using OnionHR.Application.Exceptions;

namespace OnionHR.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommandRequest, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
        this._logger = logger;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);

            throw new BadRequestException("Invalid Leave Type", validationResult);
        }

        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        return Unit.Value;
    }
}
