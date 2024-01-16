using FluentValidation;

namespace OnionHR.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommandRequest>
    {
        public UpdateLeaveTypeCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} may not be empty")
                .MaximumLength(70).WithMessage("{PropertyName} cannot be longer than 70 characters");

            RuleFor(t => t.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} has to be an integer greater than 0")
                .LessThan(100).WithMessage("{PropertyName} has to be lesser than 100");
        }
    }
}
