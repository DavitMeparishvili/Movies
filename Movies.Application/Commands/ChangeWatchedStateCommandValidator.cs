using FluentValidation;

namespace Movies.Application.Commands
{
    public sealed class ChangeWatchedStateCommandValidator : AbstractValidator<ChangeWatchedStateCommand>
    {
        public ChangeWatchedStateCommandValidator()
        {
            RuleFor(x => x.WatchListId).NotEmpty();
            RuleFor(x => x.WatchedState).NotEmpty();
        }
    }

}
