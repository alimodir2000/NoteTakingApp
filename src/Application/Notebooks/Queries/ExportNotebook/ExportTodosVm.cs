namespace NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

public class ExportNotebookVm
{
    public ExportNotebookVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
}
