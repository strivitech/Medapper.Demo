using MediatR;

namespace Medapper.Demo.Contracts.Requests;

public class UpdateUserRequest : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}