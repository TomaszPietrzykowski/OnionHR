using MediatR;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommandRequest, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }

        // public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) => this._leaveTypeRepository = leaveTypeRepository;
        // ^^^ one-liner with lambda as a shorthand for constructor injection

        public async Task<Unit> Handle(DeleteLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            // get domain object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // verify it exists

            // delete from db
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // return
            return Unit.Value;
        }
    }
}
