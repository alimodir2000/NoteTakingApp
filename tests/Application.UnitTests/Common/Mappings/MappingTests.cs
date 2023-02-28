using System.Runtime.Serialization;
using AutoMapper;
using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Application.Common.Models;
using NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;
using NoteTakingAppSolution.Domain.Entities;
using NUnit.Framework;

namespace NoteTakingAppSolution.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Notebook), typeof(NotebookDto))]
    [TestCase(typeof(Note), typeof(NoteDto))]
    [TestCase(typeof(Notebook), typeof(LookupDto))]
    [TestCase(typeof(Note), typeof(LookupDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
