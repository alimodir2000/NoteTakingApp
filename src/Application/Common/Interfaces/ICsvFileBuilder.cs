using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

namespace NoteTakingAppSolution.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildNotebookFile(IEnumerable<ExportNotebookRecord> records);
}
