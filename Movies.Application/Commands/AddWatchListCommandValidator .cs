using FluentValidation;
namespace Movies.Application.Commands;

public sealed class AddWatchListCommandValidator : AbstractValidator<AddWatchListCommand>
{
    public AddWatchListCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().MaximumLength(250);
        RuleFor(x => x.MovieId).NotEmpty().MaximumLength(250);
    }
}
