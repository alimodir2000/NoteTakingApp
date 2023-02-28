using MediatR;
using Microsoft.Extensions.Logging;

namespace NoteTakingAppSolution.Application.Common.Behaviours;
/// <summary>
/// Implementaion of MediatR IPipelineBehavior that aggregates all Execptions that aggregates throw exeptions 
/// in the application
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "NoteTakingAppSolution Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
