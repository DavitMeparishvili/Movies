using FluentValidation;

namespace Movies.Application.Queries
{
    public sealed class GetWatchListValidator : AbstractValidator<GetWatchListQuery>
    {
        public GetWatchListValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
