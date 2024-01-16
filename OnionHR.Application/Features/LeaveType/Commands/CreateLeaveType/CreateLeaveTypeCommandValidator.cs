using FluentValidation;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommandRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("{PropertyName}is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} cannot be longer than 70 characters");

            RuleFor(t => t.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} has to be an integer greater than 0")
                .LessThan(100).WithMessage("{PropertyName} has to be lesser than 100");

            RuleFor(t => t)
                .MustAsync(LeaveTypeNameUnique).WithMessage("Leave Type already exists");

            this._leaveTypeRepository = leaveTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommandRequest request, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(request.Name);
        }
    }
}
