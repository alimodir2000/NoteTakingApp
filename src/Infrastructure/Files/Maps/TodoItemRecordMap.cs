using System.Globalization;
using CsvHelper.Configuration;
using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

namespace NoteTakingAppSolution.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<ExportNotebookRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);       
    }
}
