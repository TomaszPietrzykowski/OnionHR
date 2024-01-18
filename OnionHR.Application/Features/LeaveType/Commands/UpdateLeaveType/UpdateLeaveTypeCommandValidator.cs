using FluentValidation;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommandRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(q => q.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExist);

            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} may not be empty")
                .MaximumLength(70).WithMessage("{PropertyName} cannot be longer than 70 characters");

            RuleFor(t => t.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} has to be an integer greater than 0")
                .LessThan(100).WithMessage("{PropertyName} has to be lesser than 100");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique).WithMessage("Leave Type already exists");

        }
        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommandRequest request, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeUnique(request.Name);
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);

            return leaveType != null;
        }
    }
}
