using FluentValidation;

namespace NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;

public class GetNotesWithPaginationQueryValidator : AbstractValidator<GetNotesWithPaginationQuery>
{
    public GetNotesWithPaginationQueryValidator()
    {
        RuleFor(x => x.NotebookId)
            .NotEmpty().WithMessage("ListId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
