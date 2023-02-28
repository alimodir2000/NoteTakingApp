using NoteTakingAppSolution.Application.Common.Persistence;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Infrastructure.Persistence.Repository;

public class NoteBookRepository : BaseRepository<Notebook>, INotebookRepository
{
    public NoteBookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}





