using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReminderService.Domain.Entities;
using ReminderService.Domain.Utils;

namespace ReminderService.Application.Validators
{
    public class ReminderValidator : AbstractValidator<Reminder>
    {
        public ReminderValidator()
        {
            RuleFor(x => x.To)
            .NotEmpty()
            .WithMessage("Reminder's 'To' field cannot be empty.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Reminder's 'Content' field cannot be empty.");

            RuleFor(x => x.SendAt)
                .NotEmpty()
                .WithMessage("Reminder's 'SendAt' field cannot be empty.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Reminder's 'SendAt' field cannot be in the past.");

            RuleFor(x => x.Method)
                .NotEmpty()
                .WithMessage("Reminder's 'Method' field cannot be empty.")
                .Must(x => x.ToLower() == "email" || x.ToLower() == "telegram")
                .WithMessage("Reminder's 'Method' field must be either 'email' or 'telegram'.");

            When(x => x.Method.ToLower() == StrategyConstants.EmailStrategy, () =>
            {
                RuleFor(x => x.To)
                    .EmailAddress()
                    .WithMessage("For Email method, 'To' field must be a valid email address.");
            });
        }

    }
}
