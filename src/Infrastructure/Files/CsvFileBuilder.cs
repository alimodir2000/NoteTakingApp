using System.Globalization;
using NoteTakingAppSolution.Application.Common.Interfaces;
using NoteTakingAppSolution.Infrastructure.Files.Maps;
using CsvHelper;
using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

namespace NoteTakingAppSolution.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildNotebookFile(IEnumerable<ExportNotebookRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
