using NoteTakingAppSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NoteTakingAppSolution.Application.Common.Persistence;
/// <summary>
/// The interface of database context of the application.
/// The implementation is in infrastructure.
/// </summary>
public interface IApplicationDbContext
{
    DbSet<Notebook> Notebooks { get; }

    DbSet<Note> Notes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}


