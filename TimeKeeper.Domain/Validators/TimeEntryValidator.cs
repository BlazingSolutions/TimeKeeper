using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Domain.Validators
{
    public class TimeEntryValidator : AbstractValidator<TimeEntry>
    {        
        public TimeEntryValidator()
        {
            RuleFor(p => p.Client).GreaterThan(0).WithMessage("Please select client");
            RuleFor(p => p.Category).GreaterThan(0).WithMessage("Please select category");
            RuleFor(p => p.Notes).NotEmpty().WithMessage("Please provide a note");
            RuleFor(p => p.Notes).MaximumLength(100).WithMessage("Maximum of 200 characters allowed");
            RuleFor(p => p.Hours).NotEmpty().WithMessage("Please enter hours worked");
            RuleFor(p => p.Hours).GreaterThan(0).WithMessage("Hours worked must be greater than zero");
            RuleFor(p => p.Hours).LessThan(24).WithMessage("Hours worked must be less than twenty four");
        }
    }
}
