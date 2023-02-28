using NoteTakingAppSolution.Application.Common.Persistence;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Infrastructure.Persistence.Repository;

public class NoteRepository : BaseRepository<Note>, INoteRepository
{
    public NoteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

   
}





