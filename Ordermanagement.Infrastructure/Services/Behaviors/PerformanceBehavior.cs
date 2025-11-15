using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ordermanagement.Infrastructure.Services.Behaviors;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    private readonly Stopwatch _timer = new();

    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();

        if (_timer.ElapsedMilliseconds > 1000)
            _logger.LogWarning($"Long running request: {typeof(TRequest).Name} ({_timer.ElapsedMilliseconds}ms)");

        return response;
    }
}