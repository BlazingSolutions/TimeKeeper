using FluentValidation;
using MediatR;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
{
    public class Create
    {
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Category).GreaterThan(0).WithMessage("Please select a category");
                RuleFor(x => x.Client).GreaterThan(0).WithMessage("Please select a client");
                RuleFor(x => x.Notes).NotEmpty().NotNull();
                RuleFor(x => x.Hours).GreaterThan(0);
            }
        }
    
        public record Command : IRequest<int>
        {
            public int Category { get; set; }
            public int Client { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
            public int UserId { get; set; }
        }
    }
}