using System.Diagnostics;
using MediatR;

namespace Medapper.Demo.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();
        
        Console.WriteLine($"Request: {typeof(TRequest).Name} took {_timer.ElapsedMilliseconds} ms");
    
        return response;
    }
}