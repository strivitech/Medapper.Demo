using MediatR;

namespace Medapper.Demo.Contracts.Requests;

public class CreateUserRequest : IRequest
{
    public string Name { get; set; } = null!;
}