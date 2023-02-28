namespace NoteTakingAppSolution.Domain.Exceptions;
/// <summary>
/// Domain Exeption
/// </summary>
public class UnsupportedColourException : Exception
{
    public UnsupportedColourException(string code)
        : base($"Colour \"{code}\" is unsupported.")
    {
    }
}
