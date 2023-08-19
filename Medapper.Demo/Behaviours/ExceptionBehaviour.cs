using MediatR;

namespace Medapper.Demo.Behaviours;

public class ExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            Console.WriteLine($"Request: {requestName} failed with exception: {ex.Message}");

            throw;
        }
    }
}