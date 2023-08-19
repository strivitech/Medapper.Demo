using MediatR.Pipeline;

namespace Medapper.Demo.Behaviours;

public class LogRequestNamePreProcessor<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull 
{
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Request: {typeof(TRequest).Name}");
        return Task.CompletedTask;
    }
}