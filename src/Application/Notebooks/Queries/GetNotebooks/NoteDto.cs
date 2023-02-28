using AutoMapper;
using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

public class NoteDto : IMapFrom<Note>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteDto>();
            
    }
}
