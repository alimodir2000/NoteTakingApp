using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.Common.Persistence;

public interface INotebookRepository : IAsyncRepository<Notebook>
{
}


