using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<Notebook>, IMapFrom<Note>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
