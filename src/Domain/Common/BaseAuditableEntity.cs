namespace NoteTakingAppSolution.Domain.Common;

/// <summary>
/// Base class for the entity that provider required data for traceablity of the operation
/// in case they are required.
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
