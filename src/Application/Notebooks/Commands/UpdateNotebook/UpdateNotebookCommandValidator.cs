using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notebooks.Commands.UpdateNotebook;

public class UpdateNotebookCommandValidator : AbstractValidator<UpdateNotebookCommand>
{
   
    public UpdateNotebookCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
            
    }

}
