using NoteTakingAppSolution.Application.Common.Interfaces;

namespace NoteTakingAppSolution.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
