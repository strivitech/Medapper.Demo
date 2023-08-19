using MediatR;

namespace Medapper.Demo.Contracts.Requests;

public class DeleteUserRequest : IRequest
{
    public Guid Id { get; set; }
}